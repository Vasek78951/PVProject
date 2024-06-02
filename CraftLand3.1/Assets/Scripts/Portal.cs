using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour, InteractiveObject
{
    public int sceneIdnex;
    public InventorySave InventorySaveLoad;
    public InventoryManager InventoryManager;

    public void Interact()
    {
        SceneManager.LoadScene(sceneIdnex);
        InventorySaveLoad.SaveInventory(InventoryManager);
    }

    public void StopInteraction()
    {
        // Implement behavior to stop portal interaction if needed
    }
}
