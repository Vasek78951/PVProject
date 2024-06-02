

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public InventorySave inventorySaveLoad;

    private void Start()
    {
        LoadInventory();
    }

    private void LoadInventory()
    {
        inventorySaveLoad.LoadInventory(inventoryManager);
    }
}


[System.Serializable]
public class PlayerData
{
    public int level;
    public float experience;
    public int coins;
    public InventorySlot[] inventorySlots;
    // Add other player data fields as needed
}
