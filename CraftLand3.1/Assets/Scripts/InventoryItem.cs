using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor.UIElements;
using TMPro;
using UnityEditor.Animations;
using UnityEngine.InputSystem.XR;
using static Item;
using System.Data;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Item item;
    public TextMeshProUGUI countText;

    [HideInInspector] public Image image;
    [HideInInspector] public int count = 1;
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public AnimatorController animatorController;
    [HideInInspector] public ItemType type;
    [HideInInspector] public ActionType actionType;
    [HideInInspector] public float damage;
    [HideInInspector] public ItemRule itemRule;

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.sprite;
        animatorController = newItem.animatorController;
        type = newItem.type;
        actionType = newItem.actionType;
        damage = newItem.damage;
        itemRule = newItem.itemRule;
        RefreshCount();
    }
    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textVisible = count > 1;
        countText.gameObject.SetActive(textVisible);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End drag");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
}
