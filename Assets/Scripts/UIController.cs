/***************************************************************
*file: UIController.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose: This script is responsible for controlling the UI buttons
*in the game. Each button has its own function to be called when clicked on.
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    //function: StartButtonClicked
    //purpose: This function is called when the start button is clicked on the scene. It calls the StartGame function from the GameManager instance.
    public void StartButtonClicked()
    {
        GameManager.instance.StartGame(); 
    }

    //function: ContinueButtonClicked
    //purpose: This function is called when the continue button is clicked on the scene. It calls the ContinueGame function from the GameManager instance.

    public void ContinueButtonClicked()
    {
        GameManager.instance.ContinueGame(); 
    }

    //function: ExitButtonClicked
    //purpose: This function is called when the exit button is clicked on the scene. It calls the ExitGame function from the GameManager instance.
    public void ExitButtonClicked()
    {
        GameManager.instance.ExitGame(); 
    }

    //function: CreditsButtonClicked
    //purpose: This function is called when the credits button is clicked on the scene. It calls the Credits function from the GameManager instance.
    public void CreditsButtonClicked()
    {
        GameManager.instance.Credits(); 
    }

    //function: BackButtonClicked
    //purpose: This function is called when the back button is clicked on the scene. It calls the Back function from the GameManager instance.
    public void BackButtonClicked()
    {
        GameManager.instance.Back(); 
    }
}
