using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFlag : MonoBehaviour
{

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
