using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boat : MonoBehaviour, InteractiveObject
{
    public List<Item> requiredItems;
    private int currentItemIndex = 0;
    private InventoryManager inventoryManager;
    public SpriteRenderer curentItemNeededImage;
    public bool completed;

    private void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        if (inventoryManager == null)
        {
            Debug.LogError("Boat: InventoryManager not found in the scene.");
        }
    }

    public void Interact()
    {
        Debug.Log("Interacting with boat");
        if (inventoryManager == null)
        {
            Debug.LogError("Boat: Cannot interact without InventoryManager.");
            return;
        }

        if (currentItemIndex >= requiredItems.Count)
        {
            Debug.Log("Boat: All required items have been supplied.");
            completed = true;
            return;
        }

        Item currentItem = requiredItems[currentItemIndex];
        if (inventoryManager.ContainsItem(currentItem))
        {
            if (inventoryManager.RemoveItem(currentItem))
            {
                Debug.Log("Boat: Removed " + currentItem.name + " from inventory.");
                if (currentItemIndex < requiredItems.Count - 1) // Check if it's not the last item
                {
                    currentItemIndex++;
                    Debug.Log("Boat: Next required item is " + requiredItems[currentItemIndex].name);
                }
                else
                {
                    currentItemIndex++; // Increment if it's the last item to prevent rechecking in Update()
                    Debug.Log("Boat: All required items have been supplied.");
                    completed = true;
                }
            }
            else
            {
                Debug.LogError("Boat: Failed to remove " + currentItem.name + " from inventory.");
            }
        }
        else
        {
            Debug.LogWarning("Boat: Missing required item: " + currentItem.name);
        }
    }


    public void Update()
    {
        if (!completed)
        {
            curentItemNeededImage.sprite = requiredItems[currentItemIndex].sprite;
        }
        else
        {
            curentItemNeededImage.gameObject.SetActive(false);
            SceneManager.LoadScene(2);
        }
        
    }
    public void StopInteraction()
    {

    }
}
