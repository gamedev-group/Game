/***************************************************************
*file: SoundIcon.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose: This script is responsible for playing or hiding the
*sound icon based on number of clicks 
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundIconController : MonoBehaviour
{
    // reference to the game object that contains the sound slider
    public GameObject obj;

    // counter to keep track of the number of times the sound icon is clicked
    private static int countClick = 0;


    //function: SoundButtonClicked
    //purpose: This function is called when the sound icon is clicked, and it shows or hides the sound slider based on the number of clicks.
    public void SoundButtonClicked()
    {
        // increment the countClick counter
        ++countClick;
        // if the countClick is odd, show the sound slider
        if (countClick % 2 != 0)
        {
            obj.SetActive(true);
        }
        // if the countClick is even, hide the sound slider
        else
        {
            obj.SetActive(false);
        }
        // print the countClick value for debugging purposes
        print(countClick);
    }
}
