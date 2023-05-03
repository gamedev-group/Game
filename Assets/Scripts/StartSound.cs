/***************************************************************
*file: StartSound.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose: This script is responsible for playing a sound at the
*start of a game or level. It attaches to a game object that has
*an audio source component and plays the audio source when the
*game or level starts.
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; 

public class StartSound : MonoBehaviour
{
    public AudioSource s1;

    //Function: Start
    //Purpose: Start is called before the first frame update. In this
    //function, the audio source component is obtained from the game
    //object and then the audio source is played.
    void Start()
    {
        //Get the audio source component from the game object
        s1 = GetComponent<AudioSource>(); 
        //play the sound 
        s1.Play(); 
    }
}
