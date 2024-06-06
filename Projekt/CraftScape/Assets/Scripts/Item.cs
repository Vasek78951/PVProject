using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/Item")]
[System.Serializable]
public class Item : ScriptableObject
{
    // for gameplay
    public ItemType type;
    public ActionType actionType;
    public RuntimeAnimatorController animatorController;
    public float damage;
    [SerializeField] public ItemRule itemRule;

    //for UI
    public bool stacable = true;

    public Sprite sprite;

    public enum ItemType
    {
        pickaxe,
        axe,
        weapon,
        Resource 
    }

    public enum ActionType
    {
        Mine,
        attack, 
        None
    }
}
