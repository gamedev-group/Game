using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompletionController : MonoBehaviour
{
    public LevelCompletionTextDisplayController levelCompletionText; 

    public LevelCompletionTextDisplayController levelTime; 

    public GameObject levPanel;

    void Awake()
    {
        //don't show the screen in beginning 
        levPanel.SetActive(false); 
    }

    void Update()
    {
        if(GameManager.instance.won)
        {
            ShowLevelCompletion();
            GameManager.instance.won = false; 
        }
    }

    //function: ShowLevelCompletion
    //purpose: show the level completion screen when player hits the flag 
    public void ShowLevelCompletion()
    {
        levelCompletionText.renderLevelCompletionText(GameManager.instance.currentLevel); 

        GameManager.instance.levelEndTime = Time.time; 

        levelTime.renderLevelCompletionTimeText(GameManager.instance.TotalTime()); 

        //show the level completion message 
        levPanel.SetActive(true);
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

        Time.timeScale = 1f; 
    }

    //function: NextLev
    //purpose: move to th enext level when touching th flag 
    public void NextLev()
    {
        //sound effect of button click 
        SoundManagerController.PlaySoundEffect("buttonclick"); 
        //wait a little before changing the scene 
        System.Threading.Thread.Sleep(500);
        
       //move to the next level 
        GameManager.instance.IncreaseLevel(); 
        //start the time 
        GameManager.instance.levelStartTime = Time.time; 

        Time.timeScale = 1f; 
    }
}
