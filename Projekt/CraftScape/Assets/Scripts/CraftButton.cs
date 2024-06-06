using UnityEngine;
using UnityEngine.UI;

public class CraftingButton : MonoBehaviour
{

    public CraftRecipe craftRecipe;

    private InventoryManager inventoryManager;

    public void Start()
    {
        inventoryManager = FindAnyObjectByType<InventoryManager>();
    }

    public void Craft()
    {
        craftRecipe.CraftItem(inventoryManager);
    }
}
