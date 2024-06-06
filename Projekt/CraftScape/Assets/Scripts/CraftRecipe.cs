using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemAmount
{
    public Item item;
    public int amount;

}

[CreateAssetMenu]
public class CraftRecipe : ScriptableObject
{
    public List<ItemAmount> Materials;
    public List<ItemAmount> Results;
    

    public bool CanCraft(InventoryManager inventoryManager)
    {
        
        foreach (ItemAmount itemAmount in Materials)
        {
            if(inventoryManager.ItemCount(itemAmount.item) < itemAmount.amount)
            {
                Debug.Log("Cant craft");
                return false;
            }
        }
        Debug.Log("Can craft");
        return true;
    }
    
    public void CraftItem(InventoryManager inventoryManager)
    {
        Debug.Log("Crafting");
        if (CanCraft(inventoryManager))
        {
            
            foreach (ItemAmount itemAmount in Materials)
            {
                for (int i = 0; i < itemAmount.amount; i++)
                {
                    inventoryManager.RemoveItem(itemAmount.item);
                    Debug.Log("removing: " + itemAmount.item);
                }
                
            }
            
            foreach (ItemAmount itemAmount in Results)
            {
                for (int i = 0; i < itemAmount.amount; i++)
                {
                    inventoryManager.AddItem(itemAmount.item);
                    Debug.Log("item crafte: " + itemAmount.item);
                }

            }
        }
    }

}


