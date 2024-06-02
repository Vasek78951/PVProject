using UnityEngine;

public class ExpandableButton : MonoBehaviour
{
    public GameObject[] nestedButtons; // Array to hold the nested buttons

    public void ShowButtons()
    {
        // Check if the second nested button is active
        if (nestedButtons.Length > 1 && nestedButtons[1].activeSelf)
        {
            HideAll();
        }
        else
        {
            // Show all nested buttons
            ShowAll();
        }
    }

    public void HideAll()
    {
        // Hide all nested buttons
        foreach (GameObject button in nestedButtons)
        {
            button.SetActive(false);
        }
    }

    public void ShowAll()
    {
        // Show all nested buttons
        foreach (GameObject button in nestedButtons)
        {
            button.SetActive(true);
        }
    }
}
