using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class UiManger : MonoBehaviour
{
    public Image UIMenu;
    public GameObject buildMenu;
    public GameObject invetory;
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
            if (buildMenu.active)
            {
                foreach (ExpandableButton expandableButton in expandableButtons)
                {
                    expandableButton.HideAll();
                }
                buildMenu.gameObject.SetActive(false);
                
                return;
            }
            if (invetory.active)
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
