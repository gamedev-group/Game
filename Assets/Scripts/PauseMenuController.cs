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

    public void ResumeGame()
    {
        pauseMenu.SetActive(false); 
        Time.timeScale = 1f; 
        isGamePaused = false; 
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; 
        isGamePaused = true; 
    }

    public void MenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu"); 
        Time.timeScale = 1f; 
    }

    public void QuitButtonClicked()
    {
        Application.Quit(); 
    }

    public void ResetLevel()
    {
        GameManager.instance.ResetLevel(); 
        Time.timeScale = 1f; 
    }
}
