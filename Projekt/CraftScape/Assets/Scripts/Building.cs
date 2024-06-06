using UnityEngine;

public class Building : MonoBehaviour, InteractiveObject
{
    public BuildingMenu menuPrefab;
    private BuildingMenu menuInstance;
    public void Initialize(Canvas playerCanvas)
    {
        menuInstance = Instantiate(menuPrefab, playerCanvas.transform);
    }
    public void Interact()
    {
        if (menuInstance != null)
        {
            menuInstance.ShowMenu();
        }
    }

    public void StopInteraction()
    {
        if (menuInstance != null)
        {
            menuInstance.HideMenu();
        }
    }
}

