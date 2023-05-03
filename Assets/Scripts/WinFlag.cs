/***************************************************************
*file: WinFlag.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose: Attatch to the flag to detect when the player is completing a level 
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFlag : MonoBehaviour
{
    //function: OnTriggerEnter2D
    //purpose: detect collision with the flag 
    void OnTriggerEnter2D(Collider2D other) {
        //flag collides with the player -> player reaching the goal 
        if(other.gameObject.tag == "Player")
        {
            //play the level completion sound effect 
            SoundManagerController.PlaySoundEffect("levcomp"); 
            //wait to play the sound effect 
            System.Threading.Thread.Sleep(800);
            
            GameManager.instance.won = true; 
        }
    }
}
