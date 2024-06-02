using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor.Animations;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    Vector2 direction; 
    public float movSpeed;
    public float speedX, speedY;
    Rigidbody2D rb;
    public ContactFilter2D contactFilter;
    List<RaycastHit2D> castCollisons = new List<RaycastHit2D>();
    SpriteRenderer spriteRenderer;
    Animator animator;
    public Animator itemAnimator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    void FixedUpdate()
    {
        speedX = Input.GetAxisRaw("Horizontal");
        speedY = Input.GetAxisRaw("Vertical");
        direction = new Vector2(speedX, speedY).normalized;
        //rb.velocity = direction * movSpeed;
        
        if (direction != Vector2.zero)
        {
            bool success = TryMove(direction);

            if (!success)
            {
                success = TryMove(new Vector2(direction.x, 0));
            }
            if (!success)
            {
                success = TryMove(new Vector2(0, direction.y));
            }
            animator.SetBool("isMoving", success);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }else if (direction.x > 0) 
        {
            spriteRenderer.flipX = false;
        }
        
    }
    private bool TryMove(Vector2 direction)
    {
        if(direction != Vector2.zero)
        {
            float count = rb.Cast(direction, contactFilter, castCollisons, movSpeed * Time.fixedDeltaTime);
            if (count == 0)
            {
                
                rb.MovePosition(rb.position + direction * movSpeed * Time.fixedDeltaTime);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            //cant move if there is no direction to move in
            return false;
        }
        
    }
    private void Attack()
    {
        if (itemAnimator != null)
        {
            itemAnimator.SetTrigger("Attack");
        }
       
    }
}
