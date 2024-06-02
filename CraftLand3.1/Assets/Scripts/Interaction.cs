using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required for checking UI interaction

public class Interaction : MonoBehaviour
{
    public Image image; // Interaction indicator image
    public Canvas canvas;
    public Indicator indicator;
    public LayerMask layerMask;
    public bool canInteract;
    private InteractiveObject currentObject; // Store a reference to the current interactive object
    public InputManager inputManager;
    public UiManger uiManger;

    public bool GetCanInteract()
    {
        return canInteract;
    }

    public void ShowCanvas(Vector2 position, Vector2 scale)
    {
        image.gameObject.SetActive(true);
        position = new Vector2(position.x, position.y - (scale.y / 1.2f));
        image.transform.position = position;
        canvas.transform.localScale = scale;
        canInteract = true;
    }

    public void HideCanvas()
    {
        image.gameObject.SetActive(false);
        canInteract = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentObject == null && canInteract)
            {
                RaycastHit2D hit = Physics2D.Raycast(indicator.cellIndicator.transform.position, Vector2.zero, 0, layerMask);
                if (hit.collider != null)
                {
                    GameObject hitObject = hit.collider.gameObject;
                    InteractiveObject interactiveObject = hitObject.GetComponent<InteractiveObject>();

                    if (interactiveObject != null)
                    {
                        currentObject = interactiveObject;
                        currentObject.Interact();
                        uiManger.canOpen = false;
                    }
                }
            }
            else if (currentObject != null)
            {
                currentObject.StopInteraction();
                currentObject = null;
                uiManger.canOpen = true;
            }
        }
    }
}
