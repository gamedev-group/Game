/***************************************************************
*file: PlayerHealth.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*
*purpose: determine the health of the player to see if the player can continue the level or the level is reset based on the damages
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int currentHealth = 1; 

    //function: TakeDamage
    //purpose: this function's purpose is to remove [damage] points from the player's current health. 
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth == 0)
        {
            if(GameManager.instance.hitEnemyOrSpike == "Spike")
            {
                //sound effect of spike 
                SoundManagerController.PlaySoundEffect("spike"); 
                //wait to play the sound effect 
                System.Threading.Thread.Sleep(600);
            }
            else if(GameManager.instance.hitEnemyOrSpike == "Enemy")
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
