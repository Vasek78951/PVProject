using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddingItems : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickUp;

    public void PickUpItem(int id)
    {
        bool result = inventoryManager.AddItem(itemsToPickUp[id]);
        if(result) 
        {
            Debug.Log("Item added");
        }
        else
        {
            Debug.Log("Invetory is full");
        }
    }
    public void GetSelectedItem()
    {
        Item receivedItem = inventoryManager.GetSelectedItem(false);
        if(receivedItem != null)
        {
            Debug.Log("Received: " + receivedItem);
        }
        else
        {
            Debug.Log("No itme received");
        }
    }
    public void UseSelectedItem()
    {
        Item receivedItem = inventoryManager.GetSelectedItem(true);
        if (receivedItem != null)
        {
            Debug.Log("Used: " + receivedItem);
        }
        else
        {
            Debug.Log("No itme Used");
        }
    }
}
