/***************************************************************
*file: LevelCompletionController.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose: This script handles the level completion and shows the
*level completion screen on the screen when a level is completed.
*It also handles resetting the level and moving to the next level. 
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompletionController : MonoBehaviour
{
    // reference to the text display controller for the level completion text and time text
    public LevelCompletionTextDisplayController levelCompletionText; 
    public LevelCompletionTextDisplayController levelTime;

    // reference to the game object for the level completion panel
    public GameObject levPanel;

    //Function:Awake
    //purpose:Awake is called when the script instance is being loaded
    void Awake()
    {
        //don't show the screen in beginning 
        levPanel.SetActive(false); 
    }

    //Function:Update
    //Purpose: Update is called once per frame
    void Update()
    {
        //if the level is completed, show the level completion screen 
        if(GameManager.instance.won)
        {
            // display the level completion screen
            ShowLevelCompletion();
            // reset the won variable to false
            GameManager.instance.won = false;
        }
    }

    //function: ShowLevelCompletion
    //purpose: show the level completion screen when player hits the flag 
    public void ShowLevelCompletion()
    {
        // render the level completion text on the screen
        levelCompletionText.renderLevelCompletionText(GameManager.instance.currentLevel);

        // set the level end time to the current time
        GameManager.instance.levelEndTime = Time.time;

        // render the level completion time text on the screen
        levelTime.renderLevelCompletionTimeText(GameManager.instance.TotalTime());

        // show the level completion message 
        levPanel.SetActive(true);

        // freeze the game
        Time.timeScale = 0f;
    }

    //function: Reset
    //purpose: reset the level 
    public void Reset()
    {
        //reset the level 
        GameManager.instance.ResetLevel();

        //start the time 
        GameManager.instance.levelStartTime = Time.time;

        //unfreeze the game
        Time.timeScale = 1f;
    }

    //function: NextLev
    //purpose: move to th enext level when touching th flag 
    public void NextLev()
    {
        // play the button click sound effect
        SoundManagerController.PlaySoundEffect("buttonclick");

        // wait for a little before changing the scene
        System.Threading.Thread.Sleep(500);

        // move to the next level 
        GameManager.instance.IncreaseLevel();

        // start the time 
        GameManager.instance.levelStartTime = Time.time;

        //unfreeze the game
        Time.timeScale = 1f;
    }
}
