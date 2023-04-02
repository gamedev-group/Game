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
            //reset the level 
            GameManager.instance.ResetLevel(); 
        }
    }
}
