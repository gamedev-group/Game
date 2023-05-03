/***************************************************************
*file: LevelSelectorController.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose: handle the level select scene to select the level and swicth to the level's scene 
*
****************************************************************/
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorController : MonoBehaviour
{
    public int level; //the level number of the button
    public Text levelText; //the text object displaying the level number

    //function: Start
    //Purpose:Start is called before the first frame update
    void Start()
    {
        //display the level number on the button text
        levelText.text = level.ToString();
    }

    //funciton: OpenScene
    //purpose: load the corresponding level based on the button being pressed 
    public void OpenScene()
    {
        //set the current level to the level selected 
        GameManager.instance.currentLevel = level; // comment out when testing specific levels
        
        //open the corresponding level scene 
        print(level.ToString());

        //start the time of the level 
        GameManager.instance.levelStartTime = Time.time; 

        //sound effect of button click 
        SoundManagerController.PlaySoundEffect("buttonclick"); 
        
        //wait a little before changing the scene 
        System.Threading.Thread.Sleep(500);

        // Load the selected level
        SceneManager.LoadScene("Level" + level.ToString());
    }
}
