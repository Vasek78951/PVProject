using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int MaxStackItems = 10;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    public Hand hand;

    private int selectedSlot = -1;

    private void Start()
    {
        ChangeSelectedSlot(0);
    }

    private void Update()
    {
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number < 10)
                ChangeSelectedSlot(number - 1);
        }
    }

    private void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlot >= 0 && selectedSlot < inventorySlots.Length)
        {
            inventorySlots[selectedSlot].Deselect();
        }

        if (newValue >= 0 && newValue < inventorySlots.Length)
        {
            inventorySlots[newValue].Select();
            selectedSlot = newValue;
            InventorySlot slot = inventorySlots[newValue];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            hand.EquipItem(itemInSlot);
        }
        else
        {
            Debug.LogError("Invalid slot index.");
        }
    }

    public bool AddItem(Item item)
    {
        if (item.stacable)
        {
            foreach (InventorySlot slot in inventorySlots)
            {
                InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                if (itemInSlot != null && itemInSlot.item == item && itemInSlot.count < MaxStackItems)
                {
                    itemInSlot.count++;
                    itemInSlot.RefreshCount();
                    return true;
                }
            }
        }

        foreach (InventorySlot slot in inventorySlots)
        {
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }

        return false;
    }

    public bool RemoveItem(Item item)
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            InventoryItem inventoryItem = slot.GetComponentInChildren<InventoryItem>();
            if (inventoryItem != null && inventoryItem.item == item)
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
        return false;
    }

    public bool ContainsItem(Item item)
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.item == item)
            {
                return true;
            }
        }
        return false;
    }

    public int ItemCount(Item item)
    {
        int count = 0;
        foreach (InventorySlot slot in inventorySlots)
        {
            InventoryItem inventoryItem = slot.GetComponentInChildren<InventoryItem>();
            if (inventoryItem != null && inventoryItem.item == item)
            {
                count += inventoryItem.count;
            }
        }
        return count;
    }

    private void SpawnNewItem(Item item, InventorySlot slot)
    {
        if (slot == null)
        {
            Debug.LogError("SpawnNewItem: slot is null");
            return;
        }

        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    public Item GetSelectedItem(bool use)
    {
        if (selectedSlot < 0 || selectedSlot >= inventorySlots.Length)
        {
            Debug.LogError("GetSelectedItem: selectedSlot index is out of bounds");
            return null;
        }

        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
        {
            Item item = itemInSlot.item;
            if (use)
            {
                itemInSlot.count--;
                if (itemInSlot.count <= 0)
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
