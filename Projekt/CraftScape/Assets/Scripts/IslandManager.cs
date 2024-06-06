using UnityEngine;

public class IslandManager : MonoBehaviour
{
    public GameObject[] islands; // Array to hold references to all island GameObjects
    public int startingIslandIndex = 0; // Index of the starting island

    void Start()
    {
        // Disable all islands initially
        foreach (GameObject island in islands)
        {
            island.SetActive(false);
        }

        // Enable the starting island
        UnlockIsland(startingIslandIndex);
    }

    // Function to unlock an island based on index
    public void UnlockIsland(int islandIndex)
    {
        if (islandIndex >= 0 && islandIndex < islands.Length)
        {
            islands[islandIndex].SetActive(true);
        }
        else
        {
            Debug.LogError("Invalid island index!");
        }
    }
}
