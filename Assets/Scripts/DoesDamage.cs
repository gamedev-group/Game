using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoesDamage : MonoBehaviour
{
    public int contactDamage = 1;

    internal bool TryGetComponent<T>(out object rb)
    {
        throw new NotImplementedException();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //enemy gets into contact with player  
        if(collision.gameObject.CompareTag("Player") && collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            //play the enemy hit sound effect 
            SoundManagerController.PlaySoundEffect("enemyhit");
            //wait to play the sound effect 
            System.Threading.Thread.Sleep(500);

            //pass in the damage to the player 
            playerHealth.TakeDamage(this.contactDamage); 
        }

        //enemy gets into contact with spike
        if (collision.gameObject.CompareTag("Spike") && this.gameObject.CompareTag("Enemy"))
        {
            //pass in the damage to the player 
            Destroy(this.gameObject);
        }

        //Player gets into contact with spike
        if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Spike"))
        {
            //sound effect of spike 
            SoundManagerController.PlaySoundEffect("spike"); 
            //wait to play the sound effect 
            System.Threading.Thread.Sleep(400);

            //pass in the damage to the player 
            Destroy(this.gameObject);
        }
    }
}
