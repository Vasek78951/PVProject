using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class Indicator : MonoBehaviour
{
    [SerializeField] public GameObject mosueIndicator, cellIndicator;
    [SerializeField] private InputManager inputManager;
    [SerializeField] public Grid grid;
    [SerializeField] LayerMask layerMask;
    public GameObject interaction;
    public ObjectDatabaseOS database;
    public PlacementSystem placementSystem;
    [SerializeField] private float maxRange; // Maximum range from the player
    public GameObject player;
    public bool canBuild;
    public float fieldOfViewRange;
    public Hand hand;
    public DamageManager damageManager;

    // Start is called before the first frame update
    void Start()    
    {
        player = GameObject.FindWithTag("Player");
        
    }

    public Vector2 GetCellIndicatorPos()
    {
        Vector2 mousePosition = inputManager.GetSelectedPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);
        Vector3 cellIndicatorPos = grid.CellToWorld(gridPosition);
        cellIndicatorPos = new Vector3(cellIndicatorPos.x + 0.08f, cellIndicatorPos.y + 0.08f, cellIndicatorPos.z);
        return cellIndicatorPos;
    }
    // Update is called once per frame
    private void Update()
    {
        
        canBuild = true;
        Vector2 mousePosition = inputManager.GetSelectedPosition();
        Vector2 playerPosition = player.transform.position; // Assuming the Indicator script is attached to the player GameObject
        float distance = Vector2.Distance(mousePosition, playerPosition);
        // Check if the distance between player and mouse position exceeds the maximum range
        if (inputManager.isPointerOverUI())
        {
            mosueIndicator.transform.position = mousePosition;
            return;
        }


        mousePosition = inputManager.GetSelectedPosition();
        mosueIndicator.transform.position = mousePosition;

        Vector2 playerToMouse = (mousePosition - playerPosition).normalized;
        Vector2 endPoint = playerPosition + playerToMouse * maxRange;

        RaycastHit2D hit = Physics2D.Raycast(playerPosition, endPoint - playerPosition, maxRange, layerMask);

        if (hit.collider != null)
        {
            GameObject hitObject = hit.collider.gameObject;
                cellIndicator.transform.position = hitObject.transform.position;
                cellIndicator.transform.localScale = new Vector2(hitObject.GetComponent<BoxCollider2D>().size.x, hitObject.GetComponent<BoxCollider2D>().size.y);

                cellIndicator.SetActive(true);


                interaction.gameObject.GetComponent<Interaction>().HideCanvas();

                if (Input.GetMouseButtonDown(0) && !(placementSystem.GetSelectedIndex() > -1))
                {
                    damageManager.DoDamage(hand.currentItem, hitObject);

                }
                else
                {

                }

            if (hitObject.tag == "Structure" && placementSystem.GetSelectedIndex() < 0)
            {
                interaction.gameObject.GetComponent<Interaction>().ShowCanvas(cellIndicator.transform.position, cellIndicator.transform.localScale);
            }
        }
        else
        {
            cellIndicator.SetActive(false);
            interaction.gameObject.GetComponent<Interaction>().HideCanvas();
            if (Vector2.Distance(playerPosition, mousePosition) > maxRange)
            {
                cellIndicator.SetActive(false);
                interaction.gameObject.GetComponent<Interaction>().HideCanvas();
                canBuild = false;
                mosueIndicator.transform.position = mousePosition;
                return; // Exit the method early if out of range
            }
            
        }
        if (placementSystem.GetSelectedIndex() > -1)
        {
            cellIndicator.transform.localScale = new Vector2(database.objectsData[placementSystem.GetSelectedIndex()].Size.x, database.objectsData[placementSystem.GetSelectedIndex()].Size.y);
            cellIndicator.transform.position = new Vector3(GetCellIndicatorPos().x + (database.objectsData[placementSystem.GetSelectedIndex()].Size.x - 0.16f) / 2, GetCellIndicatorPos().y + (database.objectsData[placementSystem.GetSelectedIndex()].Size.y - 0.16f) / 2);
            cellIndicator.SetActive(true);
        }
    }

}
