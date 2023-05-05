/***************************************************************
*file: PauseMenuController.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose: Handle the pause menu when the player pasues the game and the buttons on the menu 
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    // A static variable to check if the game is paused
    public static bool isGamePaused = false;
    
    // A game object that represents the pause menu UI
    public GameObject pauseMenu;

    // A game object that represents the item placer UI
    public GameObject itemPlacerUI;

    ///Function:Awake
    //purpose:Awake is called when the script instance is being loaded
    void Awake()
    {
        //initially the pause menu is not shown 
        pauseMenu.SetActive(false);
    }

    //Function:Update
    //Purpose:Update is called once per frame
    void Update()
    {
        // Check if the player presses the escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If the game is paused, resume it; otherwise, pause it
            if(isGamePaused)
            {
                ResumeGame(); 
            }
            else
            {
                PauseGame(); 
            }
        }

        // When the game is paused, hide the item placer UI; otherwise, show it
        if (isGamePaused)
        {
            itemPlacerUI.SetActive(false);
        }
        else 
        {
            itemPlacerUI.SetActive(true); 
        }
    }

    //function: ResumeGame
    //purpose: resume the level that was paused 
    public void ResumeGame()
    {
        // Play a sound effect when the button is clicked
        SoundManagerController.PlaySoundEffect("buttonclick");

        // Wait for a little while before changing the scene to give time for the sound effect to play
        System.Threading.Thread.Sleep(500);

        // Hide the pause menu UI
        pauseMenu.SetActive(false);

        // Resume the time scale to normal speed
        Time.timeScale = 1f;

        // The game is not paused anymore
        isGamePaused = false;
    }

    //function: PauseGame
    //purpose: pause the current level of the game 
    public void PauseGame()
    {
        // Show the pause menu UI
        pauseMenu.SetActive(true);

        // Freeze the time scale to pause the game
        Time.timeScale = 0f;

        // The game is now paused
        isGamePaused = true;
    }

    //function: MenuButtonClicked
    //purpose: go back to main menu 
    public void MenuButtonClicked()
    {
        isGamePaused = false; 

        GameManager.instance.infiniteItems = false;

        // Play a sound effect when the button is clicked
        SoundManagerController.PlaySoundEffect("buttonclick");

        // Wait for a little while before changing the scene to give time for the sound effect to play
        System.Threading.Thread.Sleep(500);

        // Reset the level start time to 0
        GameManager.instance.levelStartTime = 0f;

        // Load the main menu scene
        SceneManager.LoadScene("MainMenu");

        // Resume the time scale to normal speed
        Time.timeScale = 1f;
    }

    //function: QuitButtonClicked
    //purpose: quit the entire game 
    public void QuitButtonClicked()
    {
        // Play a sound effect when the button is clicked
        SoundManagerController.PlaySoundEffect("buttonclick");

        // Wait for a little while before quitting to give time for the sound effect to play
        System.Threading.Thread.Sleep(500);

        // Quit the application
        Application.Quit();
    }

    //function: ResetLevel
    //purpose:  Reset the current level of the game to its initial state 
    public void ResetLevel()
    {
        //game not paused anymore 
        isGamePaused = false; 

        GameManager.instance.infiniteItems = false;

        // Play a button click sound effect to provide audio feedback to the player
        SoundManagerController.PlaySoundEffect("buttonclick");
        // Wait for a short period of time before resetting the level
        // This is done to ensure that the button click sound effect is played before
        // the scene changes
        System.Threading.Thread.Sleep(500);

        // Call the ResetLevel() function of the GameManager instance to reset the current level
        GameManager.instance.ResetLevel();

        // Resume the game by setting the time scale to 1
        // This ensures that the game continues running normally after the level is reset
        Time.timeScale = 1f; 
    }

    //name: InifiniteItemsTogglePressed
    //purpose: checks to see if the infinite toggle has been pressed activates the infinite
    //items option in GameManager
    public void InifiniteItemsTogglePressed(bool tog)
    {
        GameManager.instance.infiniteItems = tog;
    }
}
