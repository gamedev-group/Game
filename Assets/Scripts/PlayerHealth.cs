/***************************************************************
*file: PlayerHealth.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose: Determine the health of the player to see if the player
*can continue the level or the level is reset based on the damages
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //initialize currentHealth variable to 1
    private int currentHealth = 1; 

    //function: TakeDamage
    //purpose: this function's purpose is to remove [damage] points from the player's current health. 
    public void TakeDamage(int damage)
    {
        //subtract [damage] points from currentHealth variable
        currentHealth -= damage;
        
        //if currentHealth is equal to 0, it means the player has died
        if (currentHealth == 0)
        {
            //if the player collided with a spike
            if (GameManager.instance.hitEnemyOrSpike == "Spike")
            {
                //sound effect of spike 
                SoundManagerController.PlaySoundEffect("spike"); 
                //wait to play the sound effect 
                System.Threading.Thread.Sleep(600);
            }
            //if the player collided with an enemy
            else if (GameManager.instance.hitEnemyOrSpike == "Enemy")
            {
                //play the enemy hit sound effect 
                SoundManagerController.PlaySoundEffect("enemyhit");
                //wait to play the sound effect 
                System.Threading.Thread.Sleep(500);
            }
            
            //reset the level 
            GameManager.instance.ResetLevel(); 
        }
    }
}
