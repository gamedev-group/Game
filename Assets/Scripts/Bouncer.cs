using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public float bounceForce;
    public Animator animator;

    //function: OnTriggerEnter2D
    //purpose: detect collisions 
    void OnTriggerEnter2D(Collider2D other) {

        if ((other.CompareTag("Player") || other.CompareTag("Enemy"))) {
            animator.SetTrigger("contact");

            //play the spring sound effect 
            SoundManagerController.PlaySoundEffect("spring"); 

            //give viertical force to object 
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bounceForce);
        }
    }
}
