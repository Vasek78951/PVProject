using UnityEngine;
using UnityEngine.UI;

public class UiManger : MonoBehaviour
{
    public Image UIMenu;
    public GameObject buildMenu;
    public GameObject invetory;
    public GameObject ExitMenu;
    public GameObject skillPointTree;
    public KeyCode Key = KeyCode.Escape;
    public ExpandableButton[] expandableButtons;
    public bool canOpen;
    public Interaction Interaction;
    // Start is called before the first frame update
    void Start()
    {
        canOpen = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (UIMenu.IsActive())
        {
            Interaction.canInteract = false;
        }
        if (Input.GetKeyDown(Key))
        {
            if (ExitMenu.activeSelf)
            {
                ExitMenu.gameObject.SetActive(false);

                return;
            }
            if (buildMenu.activeSelf)
            {
                foreach (ExpandableButton expandableButton in expandableButtons)
                {
                    expandableButton.HideAll();
                }
                buildMenu.gameObject.SetActive(false);
                
                return;
            }
            if (invetory.activeSelf)
            {
                invetory.SetActive(false);
                return;
            }
            if (UIMenu.IsActive())
            {
                UIMenu.gameObject.SetActive(false);
                return;
            }
            else if (canOpen)
            {
                UIMenu.gameObject.SetActive(true);
            }


        }
    }
}
