using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Controlls the script displaying the level which was completed

public class LevelCompletionTextDisplayController : MonoBehaviour
{
    public String levelCompletionText;
    public Text textRendererComponent;

    //function: renderLevelCompletionText
    //purpose: add the level number to the screen 
    public void renderLevelCompletionText(int levelNumber)
    {
        textRendererComponent.text = String.Format(levelCompletionText, levelNumber);
    }

    //function: renderLevelCompletionTimeText
    //purpose: add the time as a text to the screen 
    public void renderLevelCompletionTimeText(float timeCompleted)
    {
        textRendererComponent.text = String.Format(levelCompletionText, timeCompleted);
    }
}
