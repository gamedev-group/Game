/***************************************************************
*file: DoesDamage.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose:  This script is responsible for handling damage to 
*the player caused by enemies or spikes.
*
****************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoesDamage : MonoBehaviour
{
    // the amount of damage caused by the object
    public int contactDamage = 1;

    //method from Unity's API to avoid compile errors when inheriting from MonoBehaviour
    internal bool TryGetComponent<T>(out object rb)
    {
        throw new NotImplementedException();
    }

    //function: OnCollisionEnter2D
    //purpose: detect collision with the enemies and spikes 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check if the object collided with the player and is an enemy or flying enemy
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth) && (this.gameObject.CompareTag("Enemy") || this.gameObject.CompareTag("FlyingEnemy")))
        {
            GameManager.instance.hitEnemyOrSpike = "Enemy"; // set the game manager variable to 'Enemy'
            playerHealth.TakeDamage(this.contactDamage); // pass the damage amount to the player's health script
        }

        // check if the object collided with a spike and is an enemy
        if (collision.gameObject.CompareTag("Spike") && this.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject); // destroy the enemy object
        }

        // check if the object collided with the player and is a spike
        if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Spike") && collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth2))
        {
            GameManager.instance.hitEnemyOrSpike = "Spike"; // set the game manager variable to 'Spike'
            playerHealth2.TakeDamage(this.contactDamage); // pass the damage amount to the player's health script
        }
    }
}
