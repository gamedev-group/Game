﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null; 
    public int maxLevel = 15;
    public int currentLevel = 1; 

    void Awake()
    {
        if(instance == null)
        {
            instance = this; 
        }
        else if(instance !=this)
        {
            //so we will have only 1 manager 
            Destroy(gameObject); 
        }

        //Don't destroy the object when loading the scenes to not lose information about the game (like levels or score)
        DontDestroyOnLoad(gameObject);
    }
    
    //function: ContinueGame
    //purpose: continue the game from the last level saved 
    public void ContinueGame()
    {
        //load the scene for the last saved level 
        SceneManager.LoadScene("Level" + currentLevel); 
    }

    //function: ResetLevel
    //purpose: load the same level again
    public void ResetLevel()
    {
        //load the scene for the same level again 
        SceneManager.LoadScene("Level" + currentLevel); 
    }

    //function: StartGame
    //purpose: load the level select 
    public void StartGame()
    {
        currentLevel = 1; 

        SceneManager.LoadScene("LevelSelect"); 
    }

    //function: IncreaseLevel 
    //purpose: move to the next level (next scene)
    public void IncreaseLevel()
    {
        if(currentLevel < maxLevel)
        {
            //move to the next level 
            ++currentLevel;
        }
        else
        {
            currentLevel = 1;
        }
        //load the corresponding level (scene)
        SceneManager.LoadScene("Level" + currentLevel); 
    }
}
