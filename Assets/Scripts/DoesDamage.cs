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
        if(collision.gameObject.CompareTag("Player") && collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth) && this.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.hitEnemyOrSpike = "Enemy"; 
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
        if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Spike") && collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth2))
        {
            GameManager.instance.hitEnemyOrSpike = "Spike"; 
            //pass in the damage to the player 
            playerHealth2.TakeDamage(this.contactDamage); 
        }
    }
}
