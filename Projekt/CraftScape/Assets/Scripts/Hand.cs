using UnityEngine;

public class Hand : MonoBehaviour
{
    public RuntimeAnimatorController animatorController;
    public InventoryItem currentItem;
    public Sprite sprite;
    public GameObject itemInHand;
    public PlayerMovement playerMovement;

    // Equip the specified item
    public void EquipItem(InventoryItem inventoryItem)
    {
        // Unequip the current item if there is one
        if (currentItem != null)
        {
            UnequipItem();
        }

        // Check if the new item is null or of type Resource
        if (inventoryItem == null || inventoryItem.type == Item.ItemType.Resource)
        {
            // Do not equip the item, just return
            return;
        }

        // Equip the new item
        currentItem = inventoryItem;
        itemInHand.GetComponent<SpriteRenderer>().sprite = inventoryItem.image.sprite;

        // Set the animator controller
        if (currentItem.animatorController != null)
        {
            itemInHand.GetComponent<Animator>().runtimeAnimatorController = currentItem.animatorController;
        }
        else
        {
            itemInHand.GetComponent<Animator>().runtimeAnimatorController = null;
        }

        // Assign the item's animator to the player movement script (if needed)
        Debug.Log(itemInHand.GetComponent<Animator>());
        playerMovement.itemAnimator = itemInHand.GetComponent<Animator>();
    }

    // Unequip the currently equipped item
    public void UnequipItem()
    {
        currentItem = null;
        itemInHand.GetComponent<Animator>().runtimeAnimatorController = null;
        itemInHand.GetComponent<SpriteRenderer>().sprite = null;
    }
}
