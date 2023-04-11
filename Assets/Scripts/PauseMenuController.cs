using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public static bool isGamePaused = false; 
    public GameObject pauseMenu; 

    void Awake()
    {
        pauseMenu.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused)
            {
                ResumeGame(); 
            }
            else
            {
                PauseGame(); 
            }
        }
    }

    //function: ResumeGame
    //purpose: resume the level that was paused 
    public void ResumeGame()
    {
        pauseMenu.SetActive(false); 
        Time.timeScale = 1f; 
        isGamePaused = false; 
    }

    //function: PauseGame
    //purpose: pause the current level of the game 
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; 
        isGamePaused = true; 
    }

    //function: MenuButtonClicked
    //purpose: go back to main menu 
    public void MenuButtonClicked()
    {
        //sound effect of button click 
        SoundManagerController.PlaySoundEffect("buttonclick"); 
        //wait a little before changing the scene 
        System.Threading.Thread.Sleep(500);

        SceneManager.LoadScene("MainMenu"); 

        Time.timeScale = 1f; 
    }

    //function: QuitButtonClicked
    //purpose: quit the entire game 
    public void QuitButtonClicked()
    {
        //sound effect of button click 
        SoundManagerController.PlaySoundEffect("buttonclick"); 
        //wait a little before changing the scene 
        System.Threading.Thread.Sleep(500);

        Application.Quit(); 
    }

    //function: ResetLevel
    //purpose: start over the current level of the game 
    public void ResetLevel()
    {
        GameManager.instance.ResetLevel(); 
        Time.timeScale = 1f; 
    }
}
