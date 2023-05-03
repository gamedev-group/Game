/***************************************************************
*file: LevelCompletionTextDisplayController.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose: Controls the script displaying the level number and
*completion time when a player completes a level.
*
****************************************************************/
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Controlls the script displaying the level which was completed

public class LevelCompletionTextDisplayController : MonoBehaviour
{
    // The text to be displayed on the screen
    public String levelCompletionText;

    // The text renderer component
    public Text textRendererComponent;

    // Function: renderLevelCompletionText
    // Purpose: Adds the level number to the screen when a level is completed
    public void renderLevelCompletionText(int levelNumber)
    {
        // Set the text on the text renderer component to the formatted text
        textRendererComponent.text = String.Format(levelCompletionText, levelNumber);
    }

    // Function: renderLevelCompletionTimeText
    // Purpose: Adds the completion time as a text to the screen when a level is completed
    public void renderLevelCompletionTimeText(float timeCompleted)
    {
        // Set the text on the text renderer component to the formatted text
        textRendererComponent.text = String.Format(levelCompletionText, timeCompleted);
    }
}
