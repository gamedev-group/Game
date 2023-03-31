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
}
