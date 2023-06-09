/***************************************************************
*file: SkipButtonController.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose: handle the event when the skip button is pressed based on the current level 
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipButtonController : MonoBehaviour
{
    //function: SkipButtonPressed
    //purpose: change the scene and skip the current scene 
    public void SkipButtonPressed()
    {
        //sound effect of button click 
        SoundManagerController.PlaySoundEffect("buttonclick"); 
        //wait a little before changing the scene 
        System.Threading.Thread.Sleep(500);

        //move from intro cut scene to level 1 
        if(GameManager.instance.currentLevel == 0)
        {
            GameManager.instance.IncreaseLevel(); 
        }
        //move from the last cut scene to main menu 
        else
        {
            //set the current level to 1 
            GameManager.instance.currentLevel = 1; 
            //load the main menu scene
            SceneManager.LoadScene("MainMenu"); 
        }
    }
}
