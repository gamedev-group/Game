/***************************************************************
*file: GameManager.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose: Control the levels of the game and save the state of the game 
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // singleton design pattern: only one GameManager instance exists at any given time
    public static GameManager instance = null;
   
    // the number of levels in the game
    public int maxLevel = 13;
    // the current level the player is on
    public int currentLevel = 0;

    // the start time of the current level
    public float levelStartTime;
    // the end time of the current level
    public float levelEndTime;
    // the total time the player spent on the current level
    public float totalTime;

    // whether or not the player has won the game
    public bool won = false;

    // whether or not the player has collected the magnet power-up
    public bool hasMagnet = false;
    // whether or not the player has released the magnet power-up
    public bool hasReleased = false;
    // whether or not the player has hit an enemy or a spike
    public string hitEnemyOrSpike;
    //check if the game is reset 
    public bool isReset = false; 

    //check if infinite items are required 
    public bool infiniteItems = false; 

    //function: Awake
    //purpose: Check if Gamemanager object exists. If not create it
    void Awake()
    {
        // if no GameManager instance exists, set it to this instance
        if (instance == null)
        {
            instance = this; 
        }
        else if(instance !=this)
        {
            // if another GameManager instance exists, destroy this instance
            Destroy(gameObject); 
        }

        // Don't destroy the GameManager object when loading scenes to preserve game state (like levels and score)
        DontDestroyOnLoad(gameObject);
    }
    
    //function: ContinueGame
    //purpose: continue the game from the last level saved 
    public void ContinueGame()
    {
        infiniteItems = false; 

        //start the time 
        GameManager.instance.levelStartTime = Time.time; 

        //sound effect of button click 
        SoundManagerController.PlaySoundEffect("buttonclick"); 
        //wait a little before changing the scene 
        System.Threading.Thread.Sleep(500);

        //load the scene for the last saved level 
        SceneManager.LoadScene("Level" + currentLevel); 
    }

    //function: ResetLevel
    //purpose: load the same level again
    public void ResetLevel()
    {
        isReset = true;

        infiniteItems = false; 
        
        //load the scene for the same level again 
        SceneManager.LoadScene("Level" + currentLevel); 

        //reset the time 
        GameManager.instance.levelStartTime = Time.time; 
    }

    //function: StartGame
    //purpose: load the level select 
    public void StartGame()
    {
        infiniteItems = false; 
         
        //sound effect of button click 
        SoundManagerController.PlaySoundEffect("buttonclick"); 
        //wait a little before changing the scene 
        System.Threading.Thread.Sleep(500);

        SceneManager.LoadScene("LevelSelect"); 
    }

    //function: IncreaseLevel 
    //purpose: his function is called when the player has completed
    //the current level and it is time to move to the next level (next scene).
    public void IncreaseLevel()
    {
        if(currentLevel < maxLevel)
        {
            //move to the next level 
            ++currentLevel;
        }
        else
        {
            // if the player has completed the last level, restart at level 1
            currentLevel = 1;
        }

        infiniteItems = false; 

        //load the corresponding level (scene)
        SceneManager.LoadScene("Level" + currentLevel); 
    }

    //function: TotalTime
    //purpose: Calculates the total time that has passed since the start and
    //end of the level
    public float TotalTime()
    {
        return (levelEndTime - levelStartTime); 
    }

    //function: ExitGame
    //purpose: Quits out of the game
    public void ExitGame()
    {
        Application.Quit();
    }

    //function: Credits
    //purpose: display the credits 
    public void Credits()
    {
        //sound effect of button click 
        SoundManagerController.PlaySoundEffect("buttonclick"); 
        //wait a little before changing the scene 
        System.Threading.Thread.Sleep(500);
        // Load credits scene
        SceneManager.LoadScene("Credits"); 
    }

    //function: Back
    //purpose: go back to the main menu 
    public void Back()
    {
        //sound effect of button click 
        SoundManagerController.PlaySoundEffect("buttonclick"); 
        //wait a little before changing the scene 
        System.Threading.Thread.Sleep(500);
        // Loads the Main Menu
        SceneManager.LoadScene("MainMenu"); 
    }

    //function: Guidelines
    //purpose: go to the guidelines scene 
    public void Guidelines()
    {
        //sound effect of button click 
        SoundManagerController.PlaySoundEffect("buttonclick"); 
        //wait a little before changing the scene 
        System.Threading.Thread.Sleep(500);
        // Loads the Main Menu
        SceneManager.LoadScene("Guideline"); 
    }
}
