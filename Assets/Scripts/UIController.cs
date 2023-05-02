/***************************************************************
*file: UIController.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*
*purpose: Controll the user interface with listening to button clicks 
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    //function: StartButtonClicked
    //purpose: start button is clicked on the scene, load level 1 
    public void StartButtonClicked()
    {
        GameManager.instance.StartGame(); 
    }

    //function: ContinueButtonClicked
    //purpose: continue button is clicked on the scene, load the last saved level 
    public void ContinueButtonClicked()
    {
        GameManager.instance.ContinueGame(); 
    }

    //function: ExitButtonClicked
    //purpose: exit the game 
    public void ExitButtonClicked()
    {
        GameManager.instance.ExitGame(); 
    }

    //function: CreditsButtonClicked
    //purpose: display the credits 
    public void CreditsButtonClicked()
    {
        GameManager.instance.Credits(); 
    }

    //function: BackButtonClicked
    //purpose: go back to main menu 
    public void BackButtonClicked()
    {
        GameManager.instance.Back(); 
    }
}
