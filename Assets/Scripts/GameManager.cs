using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null; 
    public int maxLevel = 4;
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
