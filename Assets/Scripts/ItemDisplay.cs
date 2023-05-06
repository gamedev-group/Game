/***************************************************************
*file: ItemDisplay.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose: Displays the currently available items to the screen and
*allows the user to interact with them by creating icons for each item,
*updating their quantities when they are used, and allowing the user to
*switch between them using the selectionChanged event.
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDisplay : MonoBehaviour
{
    public GameObject itemIcon;

    //create a dictionary to store the PlaceableScriptableObject and its corresponding item icon
    Dictionary<PlaceableScriptableObject, ItemIcon> icons = new Dictionary<PlaceableScriptableObject, ItemIcon>();


    //function:OnEnable
    //purpose: subscribe to events triggered by the ItemPlacer script
    void OnEnable() {
        //subscribe to events triggered by the ItemPlacer script
        ItemPlacer.signalDictionary += InitializeDisplay;
        ItemPlacer.itemUsed += RemoveItemQuantity;
        ItemPlacer.selectionChanged += ChangeSelectedItem;
    }

    //function:OnDisable
    //purpose: unsubscribe from events triggered by the ItemPlacer script
    void OnDisable() {
        //unsubscribe from events triggered by the ItemPlacer script
        ItemPlacer.signalDictionary -= InitializeDisplay;
        ItemPlacer.itemUsed -= RemoveItemQuantity;
        ItemPlacer.selectionChanged -= ChangeSelectedItem;
    }

    //function: InitializeDisplay
    //purpose: When the level starts, this function will create a set of all the player's items and quantities.
    void InitializeDisplay(Dictionary<PlaceableScriptableObject, int> dictionary) {
        //iterate through each item in the dictionary and create an item icon for it
        foreach (PlaceableScriptableObject item in dictionary.Keys) {
            CreateIcon(item, dictionary[item]);
        }
    }

    //function: CreateIcon
    //purpose: Creates an icon for an item and displays its quantity.
    void CreateIcon(PlaceableScriptableObject item, int quantity) {
        //instantiate a new item icon object from the prefab and store its script component
        GameObject obj = Instantiate(itemIcon, transform.position, Quaternion.identity, transform);
        ItemIcon icon = obj.GetComponent<ItemIcon>();
        //add the PlaceableScriptableObject and its corresponding item icon to the dictionary
        icons.Add(item, icon);

        //set the sprite and quantity text of the item icon
        icon.itemDisplay.sprite = item.icon;
        icon.quantityDisplay.text = quantity.ToString();
    }

    //function: RemoveItemQuantity
    //purpose: When the user places down an item, this is called to visually decrement the item quantity.
    void RemoveItemQuantity(PlaceableScriptableObject item, int newQuantity) {
        //update the quantity text of the corresponding item icon
        icons[item].quantityDisplay.text = newQuantity.ToString();
    }

    //function: ChangeSelectedItem
    //purpose: switch between the items 
    void ChangeSelectedItem(PlaceableScriptableObject item) {
        //iterate through each item in the dictionary and deselect its background
        foreach (PlaceableScriptableObject obj in icons.Keys) {
            icons[obj].DeselectBackground();
        }
        //select the background of the chosen item
        icons[item].SelectBackground();
    }
}
