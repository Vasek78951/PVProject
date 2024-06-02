using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    // for gameplay
    public ItemType type;
    public ActionType actionType;
    public Vector2Int range = new Vector2Int(5, 4);
    public AnimatorController animatorController;
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
