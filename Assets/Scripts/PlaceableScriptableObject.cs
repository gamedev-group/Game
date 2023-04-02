using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Placeable", menuName = "ScriptableObects/Placeable", order = 1)]
public class PlaceableScriptableObject : ScriptableObject
{
    public string itemName;
    public GameObject prefab;
    public Sprite icon;
}
