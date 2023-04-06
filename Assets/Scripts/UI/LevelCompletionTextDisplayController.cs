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

    public void renderLevelCompletionText(int levelNumber)
    {
        textRendererComponent.text = String.Format(levelCompletionText, levelNumber);
    }
}
