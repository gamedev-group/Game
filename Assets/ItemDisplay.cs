using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDisplay : MonoBehaviour
{
    public GameObject itemIcon;

    //TODO: refactor
    Dictionary<PlaceableScriptableObject, TextMeshProUGUI> iconQuantities = new Dictionary<PlaceableScriptableObject, TextMeshProUGUI>();

    void Awake() {
        ItemPlacer.signalDictionary += InitializeDisplay;
        ItemPlacer.itemUsed += RemoveItemQuantity;
    }

    void InitializeDisplay(Dictionary<PlaceableScriptableObject, int> dictionary) {
        foreach(PlaceableScriptableObject item in dictionary.Keys) {
            CreateIcon(item, dictionary[item]);
        }
    }

    void CreateIcon(PlaceableScriptableObject item, int quantity) {
        GameObject obj = Instantiate(itemIcon, transform.position, Quaternion.identity, transform);
        Image objDisplay = obj.GetComponent<Image>();
        TextMeshProUGUI quantityDisplay = obj.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        iconQuantities.Add(item, quantityDisplay);

        objDisplay.sprite = item.icon;
        quantityDisplay.text = quantity.ToString();
    }

    void RemoveItemQuantity(PlaceableScriptableObject item, int newQuantity) {
        iconQuantities[item].text = newQuantity.ToString();
    }
}
