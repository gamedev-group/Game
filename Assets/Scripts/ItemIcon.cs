/***************************************************************
*file: ItemIcon.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose: This script is responsible for managing the visual display of each item's icon, including
*the image of the item, the quantity of the item, and whether or not the item is currently selected. 
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemIcon : MonoBehaviour
{
    public Image itemDisplay; // Reference to the image component for the item
    public TextMeshProUGUI quantityDisplay; // Reference to the TextMeshProUGUI component for the quantity of the item
    public Image selectedBackground; // Reference to the image component for the selected background of the icon

    //function:OnEnable
    //purpose: Deselect the background when the icon is enabled
    void OnEnable() {
        DeselectBackground();
    }

    //function: SelectBackground
    //purpose: Activate the background for the icon 
    public void SelectBackground() {
        selectedBackground.gameObject.SetActive(true);
    }

    //function: DeselectBackground
    //purpose: deactivate the background for the icon 
    public void DeselectBackground() {
        selectedBackground.gameObject.SetActive(false);
    }
}
