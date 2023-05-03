/***************************************************************
*file: ItemIcon.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*
*purpose: Handle the view of each item's icon 
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemIcon : MonoBehaviour
{
    public Image itemDisplay;
    public TextMeshProUGUI quantityDisplay;
    public Image selectedBackground;

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
