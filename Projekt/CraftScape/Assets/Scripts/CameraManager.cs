using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera mainCamera; // Reference to the main camera
    public Transform player; // Reference to the player
    public float followSpeed = 5f; // Speed at which the camera follows the cursor
    public KeyCode followKey = KeyCode.F; // Key to press to enable camera follow

    public bool isFollowingCursor = false;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        if (isFollowingCursor)
        {
            FollowCursor();
        }
        else
        {
            FollowPlayer();
        }
    }

    void FollowCursor()
    {
        Vector3 mousePosition = Input.mousePosition;
        //mousePosition.z = mainCamera.transform.position.z; // Set Z to camera's Z
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // Smoothly move the camera towards the cursor
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, worldPosition, followSpeed * Time.deltaTime);
    }

    void FollowPlayer()
    {
        // Smoothly move the camera back to the player
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, player.position + new Vector3(0, 0, mainCamera.transform.position.z), followSpeed * Time.deltaTime);
    }
}
