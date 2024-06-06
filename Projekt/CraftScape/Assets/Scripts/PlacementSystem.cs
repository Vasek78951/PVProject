using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] LayerMask layerMask;
    public ObjectSpawning objectSpawning;
    public ObjectDatabaseOS database;
    public Indicator indicator;
    private int selectedObjectIndex = -1;
    public Canvas playerCanvas;
    public InventoryManager inventoryManager;

    public int GetSelectedIndex()
    {
        return selectedObjectIndex;
    }

    public void Start()
    {
        StopPlacement();
    }

    public void StartPlacement(int ID)
    {
        StopPlacement();

        selectedObjectIndex = database.objectsData.FindIndex(data => data.ID == ID);
        if (selectedObjectIndex < 0)
        {
            Debug.Log($"No ID found {ID}");
            return;
        }

        inputManager.OnClicked += PlaceStructure;
        inputManager.OnExit += StopPlacement;
    }

    private void PlaceStructure()
    {
        if (inputManager.isPointerOverUI() || !indicator.canBuild)
        {
            return;
        }

        // Check if the player has the required resources
        if (!HasRequiredResources(database.objectsData[selectedObjectIndex].requiredItems))
        {
            Debug.Log("Not enough resources to build");
            return;
        }

        GameObject gameStructure = Instantiate(database.objectsData[selectedObjectIndex].Prefab);
        Vector2 buildingPos = indicator.GetCellIndicatorPos();

        // Determine the offset based on the building size
        float xOffset = (database.objectsData[selectedObjectIndex].Size.x - 0.16f) / 2;
        float yOffset = (database.objectsData[selectedObjectIndex].Size.y - 0.16f) / 2;
        Vector2 offset = new Vector2(xOffset, yOffset);

        // Apply the offset to the building position
        buildingPos += offset;

        // Check if the position is valid
        Collider2D[] colliders = Physics2D.OverlapBoxAll(buildingPos, database.objectsData[selectedObjectIndex].Size, 0, layerMask);
        foreach (Collider2D collider in colliders)
        {
            if (collider != null)
            {
                Destroy(gameStructure);
                return;
            }
        }

        // Deduct the resources
        DeductResources(database.objectsData[selectedObjectIndex].requiredItems);

        // Set the position
        gameStructure.transform.position = buildingPos;

        // Initialize the CraftMenu in the building
        Building building = gameStructure.GetComponent<Building>();
        if (building != null)
        {
            building.Initialize(playerCanvas);
        }
    }


    private bool HasRequiredResources(List<RecipeItem> requiredItems)
    {
        foreach (RecipeItem recipeItem in requiredItems)
        {
            if (inventoryManager.ItemCount(recipeItem.item) < recipeItem.quantity)
            {
                return false;
            }
        }
        return true;
    }

    private void DeductResources(List<RecipeItem> requiredItems)
    {
        foreach (RecipeItem recipeItem in requiredItems)
        {
            for (int i = 0; i < recipeItem.quantity; i++)
            {
                inventoryManager.RemoveItem(recipeItem.item);
            }
        }
    }

    private void StopPlacement()
    {
        selectedObjectIndex = -1;
        inputManager.OnClicked -= PlaceStructure;
        inputManager.OnExit -= StopPlacement;
    }
}
