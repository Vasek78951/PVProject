using UnityEngine;

[CreateAssetMenu(fileName = "NewItemRule", menuName = "Item/Item Rule")]
public class ItemRule : ScriptableObject
{
    public Item.ItemType itemType;
    public Item.ActionType actionType;
    public string targetTag;
    public float damageMultiplier = 1.0f;
}