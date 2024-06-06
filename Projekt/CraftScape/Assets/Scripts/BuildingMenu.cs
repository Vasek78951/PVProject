using UnityEngine;

public class BuildingMenu : MonoBehaviour
{
    public void ShowMenu()
    {
        // Show the craft menu
        gameObject.SetActive(true);
    }

    public void HideMenu()
    {
        // Hide the craft menu
        gameObject.SetActive(false);
    }
}
