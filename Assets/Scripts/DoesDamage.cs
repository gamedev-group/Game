using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoesDamage : MonoBehaviour
{
    public int contactDamage = 1; 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //enemy gets into contact with player  
        if(collision.gameObject.CompareTag("Player") && collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            //pass in the damage to the player 
            playerHealth.TakeDamage(this.contactDamage); 
        }
    }
}
