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

        //enemy gets into contact with spike
        if (collision.gameObject.CompareTag("Spike") && this.gameObject.CompareTag("Enemy"))
        {
            print("Hit Spike");
            //pass in the damage to the player 
            Destroy(this.gameObject);
        }

        //enemy gets into contact with spike
        if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Spike"))
        {
            SoundManagerController.PlaySoundEffect("spike"); 

            System.Threading.Thread.Sleep(1000);
            print("yesss"); 
            //pass in the damage to the player 
            Destroy(this.gameObject);
        }
    }
}
