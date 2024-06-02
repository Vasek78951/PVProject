using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] // so it can be created in from the create menu in the editor
public class ObjectDatabaseOS : ScriptableObject
{   
    public List<ObjectData> objectsData;
}
[Serializable]
public class RecipeItem
{
    public Item item;
    public int quantity;
}

[Serializable]
public class ObjectData
{
    [field: SerializeField] // so it can be displayed in the inspector
    public string Name { get; private set; }
    [field: SerializeField]
    public int ID { get; private set; }
    [field: SerializeField]
    public Vector2 Size { get; private set; } = Vector2.one;
    [field: SerializeField]
    public GameObject Prefab { get; private set; }
    public ObjectHealth objectHealth { get; private set; }
    [field: SerializeField]
    public List<RecipeItem> requiredItems = new List<RecipeItem>();

}