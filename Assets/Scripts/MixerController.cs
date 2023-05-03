/***************************************************************
*file: MixerController.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose: The purpose of the script is to handle the volume
*slider and set the volume of the audio mixer based on the value
*of the slider. 
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; 

public class MixerController : MonoBehaviour
{
    // Refrence to an audio mixer object
    public AudioMixer audioMixer;

    //Function:Awake
    //purpose:Awake is called when the script instance is being loaded
    void Awake()
    {
        //initially, the volume slider is not shown 
       gameObject.SetActive(false); 
    }

    //function: SetVolume
    //purpose: set the volume of the music based on the slider 
    public void SetVolume(float sliderValue)
    {
        // Set the volume of the AudioMixer to the logarithmic value of the slider value 
        // multiplied by 20, which gives a reasonable range of volume for most users 
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20); 
    }
}
