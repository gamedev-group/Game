using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public GameObject itemIcon;

    void Awake() {
        ItemPlacer.signalDictionary += InitializeDisplay;
    }

    void InitializeDisplay(Dictionary<PlaceableScriptableObject, int> dictionary) {
        foreach(PlaceableScriptableObject item in dictionary.Keys) {
            CreateIcon(item);
        }
    }

    void CreateIcon(PlaceableScriptableObject item) {
        GameObject obj = Instantiate(itemIcon, transform.position, Quaternion.identity);
        Image objDisplay = obj.GetComponent<Image>();
        objDisplay.sprite = item.icon;
    }
}
