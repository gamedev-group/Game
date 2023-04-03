using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompletionController : MonoBehaviour
{
    public Text levelNumber; 
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

    public void ShowLevelCompletion()
    {
        levelNumber.text = GameManager.instance.currentLevel.ToString(); 
        //show the level completion message 
        levPanel.SetActive(true);
        Time.timeScale = 0f; 
    }

    public void Reset()
    {
        //reset the level 
        GameManager.instance.ResetLevel(); 
        Time.timeScale = 1f; 
    }

    public void NextLev()
    {
        //move to the next level 
        GameManager.instance.IncreaseLevel(); 
        Time.timeScale = 1f; 
    }
}
