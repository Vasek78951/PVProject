using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int MaxStackItems = 10;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    public Hand hand;
    int selectedSlot = -1;

    private void Start()
    {
        ChangeSelectedSlot(0);
        
    }
    private void Update()
    {
        if(Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number < 10)
                ChangeSelectedSlot(number - 1);
        }
    }
    void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].Deselect();
        }
        inventorySlots[newValue].Select();
        selectedSlot = newValue;
        InventorySlot slot = inventorySlots[newValue];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        Debug.Log("slected");
        hand.EquipItem(itemInSlot);
        
    }
    public bool AddItem(Item item)
    {
        // Check if the item is stackable
        if (item.stacable)
        {
            // Check if the item is already in the inventory and if there is space for stacking
            foreach (InventorySlot slot in inventorySlots)
            {
                InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                if (itemInSlot != null && itemInSlot.item == item && itemInSlot.count < MaxStackItems)
                {
                    itemInSlot.count++;
                    itemInSlot.RefreshCount();
                    return true; // Item added successfully
                }
            }
        }

        // If the item is not stackable or there is no space for stacking, find an empty slot and spawn a new item
        foreach (InventorySlot slot in inventorySlots)
        {
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true; // Item added successfully
            }
        }

        // If no empty slot is found, return false indicating that the item could not be added
        return false;
    }


    public bool RemoveItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem inventoryItem = slot.GetComponentInChildren<InventoryItem>();
            if (inventoryItem != null)
            {
                if (inventoryItem.item == item)
                {
                    inventoryItem.count--;
                    if (inventoryItem.count <= 0)
                    {
                        Destroy(inventoryItem.gameObject);
                    }
                    else
                    {
                        inventoryItem.RefreshCount();
                    }
                    return true;
                }
            }
        }
        return false;
    }
    public bool ContainsItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itmeInSlot = slot.GetComponentInChildren<InventoryItem>();
            
            if (itmeInSlot.item == item)
            {
                return true;
            }
        }
        return false;
    }
    public int ItemCount(Item item)
    {
        Debug.Log("counting");
        int count = 0;
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem inventoryItem = slot.GetComponentInChildren<InventoryItem>();
            if(inventoryItem != null)
            {
                if (inventoryItem.item == item)
                {
                    for(int j = 0; j < inventoryItem.count; j++)
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }
    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }
    public Item GetSelectedItem(bool use)
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
        {
            Item item = itemInSlot.item;
            if (use)
            {
                itemInSlot.count--;
                if(itemInSlot.count <= 0)
                {
                    Destroy(itemInSlot.gameObject);
                }
                else
                {
                    itemInSlot.RefreshCount();
                }
            }
            return item;
        }
        return null;
    }

}
