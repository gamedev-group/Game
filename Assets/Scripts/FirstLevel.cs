/***************************************************************
*file: FirstLevel.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose: This script handles the time control and scene transition during cutscenes.
*It calculates the elapsed time for a cutscene and advances to the next scene when the time has run out.
*It also determines whether the next scene is the main menu or the next level.
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstLevel : MonoBehaviour
{
    public float changeTime; // the duration of the cutscene

    //Function:Update
    //Purpose: Update is called once per frame
    void Update()
    {
        // Calculate the time remaining for the cutscene
        changeTime -= Time.deltaTime;

        // Check if the cutscene has ended
        if (changeTime <= 0)
        {
            // If the current cutscene is the intro, advance to level 1
            if (GameManager.instance.currentLevel == 0)
            {
                GameManager.instance.IncreaseLevel(); 
            }
            // If the current cutscene is the last one, go back to the main menu
            else if (GameManager.instance.currentLevel == GameManager.instance.maxLevel)
            {
                SceneManager.LoadScene("MainMenu"); 
            }
        }
    }
}
