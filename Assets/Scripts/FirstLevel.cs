/***************************************************************
*file: FirstLevel.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*
*purpose: handle the change scene for the cut scenes 
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstLevel : MonoBehaviour
{
    public float changeTime; 
    void Update()
    {
        //calculate the time passed from the start of the cut scene 
        changeTime -= Time.deltaTime;

        //if it reached 0 then 
        if(changeTime <= 0)
        {
            //increase the level to 1 if the current cut scene is the intro one 
            if(GameManager.instance.currentLevel == 0)
            {
                GameManager.instance.IncreaseLevel(); 
            }
            //change it to main menu scene if the current cut scene is the last cut scene 
            else if(GameManager.instance.currentLevel == GameManager.instance.maxLevel)
            {
                SceneManager.LoadScene("MainMenu"); 
            }
        }
    }
}
