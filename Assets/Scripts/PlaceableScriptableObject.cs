/***************************************************************
*file: PlaceableScriptableObject.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*
*purpose: Give attributes to the items being displayed on the screen and used by the player 
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Placeable", menuName = "ScriptableObects/Placeable", order = 1)]
public class PlaceableScriptableObject : ScriptableObject
{
    public string itemName;
    public GameObject prefab;
    public Sprite icon;
    public bool requiresGround;
}
