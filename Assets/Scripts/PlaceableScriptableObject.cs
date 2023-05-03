/***************************************************************
*file: PlaceableScriptableObject.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose: Give attributes to the items being displayed on the screen and used by the player 
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creates a new scriptable object in Unity's asset menu
[CreateAssetMenu(fileName = "Placeable", menuName = "ScriptableObects/Placeable", order = 1)]
public class PlaceableScriptableObject : ScriptableObject
{
    //Stores the name of the item as a public string
    public string itemName;
    //Stores the item's prefab as a public GameObject
    public GameObject prefab;
    //Stores the item's icon as a public Sprite
    public Sprite icon;
    //Stores a boolean value that indicates whether the item requires a ground to be placed on
    public bool requiresGround;
}
