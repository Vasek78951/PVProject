using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    // Player attributes
    public int level;
    public float experience;
    public int coins;
    public InventorySlot[] inventory;// vsechno se musi ukladat zde. musm dodelat!

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Ensure PlayerController persists across scene changes
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Add methods for player actions, interactions, inventory management, etc.
}
