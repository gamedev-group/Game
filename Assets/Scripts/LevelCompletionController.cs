using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompletionController : MonoBehaviour
{
    public LevelCompletionTextDisplayController levelCompletionText; 
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
        Time.timeScale = 1f; 
    }

    //function: NextLev
    //purpose: move to th enext level when touching th flag 
    public void NextLev()
    {
        //move to the next level 
        GameManager.instance.IncreaseLevel(); 
        Time.timeScale = 1f; 
    }
}
