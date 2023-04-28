using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipButtonController : MonoBehaviour
{
    public void SkipButtonPressed()
    {
        //sound effect of button click 
        SoundManagerController.PlaySoundEffect("buttonclick"); 
        //wait a little before changing the scene 
        System.Threading.Thread.Sleep(500);

        GameManager.instance.IncreaseLevel(); 
    }
}
