using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDisplay : MonoBehaviour
{
    public GameObject itemIcon;

    //TODO: refactor
    Dictionary<PlaceableScriptableObject, ItemIcon> icons = new Dictionary<PlaceableScriptableObject, ItemIcon>();

    void Awake() {
        ItemPlacer.signalDictionary += InitializeDisplay;
        ItemPlacer.itemUsed += RemoveItemQuantity;
        ItemPlacer.selectionChanged += ChangeSelectedItem;
    }

    //function: InitializeDisplay
    //purpose: When the level starts, this function will create a set of all the player's items and quantities.
    void InitializeDisplay(Dictionary<PlaceableScriptableObject, int> dictionary) {
        foreach(PlaceableScriptableObject item in dictionary.Keys) {
            CreateIcon(item, dictionary[item]);
        }
    }

    //function: CreateIcon
    //purpose: Creates an icon for an item and displays its quantity.
    void CreateIcon(PlaceableScriptableObject item, int quantity) {
        GameObject obj = Instantiate(itemIcon, transform.position, Quaternion.identity, transform);
        ItemIcon icon = obj.GetComponent<ItemIcon>();
        icons.Add(item, icon);

        icon.itemDisplay.sprite = item.icon;
        icon.quantityDisplay.text = quantity.ToString();
    }

    //function: RemoveItemQuantity
    //purpose: When the user places down an item, this is called to visually decrement the item quantity.
    void RemoveItemQuantity(PlaceableScriptableObject item, int newQuantity) {
        icons[item].quantityDisplay.text = newQuantity.ToString();
    }

    void ChangeSelectedItem(PlaceableScriptableObject item) {
        foreach(PlaceableScriptableObject obj in icons.Keys) {
            icons[obj].DeselectBackground();
        }
        icons[item].SelectBackground();
    }
}
