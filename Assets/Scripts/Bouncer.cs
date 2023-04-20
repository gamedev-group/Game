using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public float bounceForce;
    public Animator animator;

    void OnTriggerEnter2D(Collider2D other) {
        animator.SetTrigger("contact");

        if (other.CompareTag("Player")) {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bounceForce);
            //play the spring sound effect 
            SoundManagerController.PlaySoundEffect("spring"); 
        }
        // TODO: Figure out why spring doesn't launch enemy
        if (other.CompareTag("Enemy"))
        {
            print("Hit Enemy");
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bounceForce);
        }
    }
}
