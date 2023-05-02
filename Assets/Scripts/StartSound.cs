/***************************************************************
*file: StartSound.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*
*purpose: Starting the sound from the first frame 
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; 

public class StartSound : MonoBehaviour
{
    public AudioSource s1; 

    // Start is called before the first frame update
    void Start()
    {
        s1 = GetComponent<AudioSource>(); 
        //play the sound 
        s1.Play(); 
    }
}
