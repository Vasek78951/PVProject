using UnityEngine;
using System.Collections.Generic;

public class InventorySave : MonoBehaviour
{
    public Canvas playerCanvas;
    private void Awake()
    {
        if(playerCanvas == null)
        {
            DontDestroyOnLoad(playerCanvas);
        }
        else
        {
            Destroy(playerCanvas);
        }
        
    }
    public void SaveInventory(InventoryManager inventoryManager)
    {
        List<Item> items = new List<Item>();

        // Iterate through each slot in the inventory
        foreach (InventorySlot slot in inventoryManager.inventorySlots)
        {
            InventoryItem item = slot.GetComponentInChildren<InventoryItem>();
            if (item != null && item.item != null)
            {
                // Save a reference to each item object
                items.Add(item.item);
            }
            else
            {
                // If the slot is empty, save a null reference
                items.Add(null);
            }
        }

        // Convert the list of item objects to a JSON string and save it using PlayerPrefs
        string itemsJson = JsonUtility.ToJson(items);
        PlayerPrefs.SetString("InventoryItems", itemsJson);
    }

    public void LoadInventory(InventoryManager inventoryManager)
    {
        // Retrieve the saved item objects from PlayerPrefs
        string itemsJson = PlayerPrefs.GetString("InventoryItems");
        List<Item> items = JsonUtility.FromJson<List<Item>>(itemsJson);

        // Iterate through each item object and add it to the inventory
        foreach (Item item in items)
        {
            if (item != null)
            {
                inventoryManager.AddItem(item);
            }
        }
    }
}
