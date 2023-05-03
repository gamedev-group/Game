/***************************************************************
*file: UIParalaxLayer.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose:  Attach to a UI element to make it move in reaction to
*the mouse position on the screen.
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Causes UI elements this behavior is attached to to change their position as a reaction to the mouse position in screen

public class UIParalaxLayer : MonoBehaviour
{
    // The amount of translation for the UI element.
    [SerializeField]
    private float translationAmount = 0.0f;

    // RectTransform component of the UI element.
    private RectTransform rectTransform;

    //Function: Start
    //Purpose:Start is called before the first frame update
    void Start()
    {
        // initialize the RectTransform component of the UI element.
        rectTransform = GetComponent<RectTransform>();
    }

    //Function:Update
    //Purpose: Update is colled once per frame
    void Update()
    {
        // Set the anchored position of the RectTransform based on the mouse position
        rectTransform.anchoredPosition3D = getAdjustedMousePosition() * translationAmount;
    }

    //Function: getAdujustedMousePosition
    //Purpose:Get the position of the mouse adjusted so that (-1,-1) is the bottom left corner of the screen 
    // and (1,1) is the top right corner.
    Vector3 getAdjustedMousePosition()
    {
        // Get the raw mouse position
        Vector3 rawMousePosition = Input.mousePosition;

        // Convert the x and y positions of the mouse to a range from -1 to 1
        float adjustedXPosition = ((rawMousePosition.x / Screen.width) * 2f) - 1f;
        float adjustedYPosition = ((rawMousePosition.y / Screen.height) * 2f) - 1f;

        // Return the adjusted mouse position as a Vector3
        return new Vector3(adjustedXPosition, adjustedYPosition, 0f);
    }
}
