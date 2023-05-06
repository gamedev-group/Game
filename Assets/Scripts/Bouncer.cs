/***************************************************************
*file: BlockController.cs
*author: Group
*class: CS 4700 – Game Development
*assignment: Final Project
*date last modified: 5/03/2023
*
*purpose: This script is used to make an object act as a bouncer.
*    When a Player or Enemy collides with this object, they
*    are launched upwards.
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public float bounceForce; //the force to be applied on the colliding object
    public Animator animator; //the animator component attached to the bouncer

    //function: OnTriggerEnter2D
    //purpose: detect collisions with other objects that have 2D colliders 
    void OnTriggerEnter2D(Collider2D other)
    {
        //if the colliding object is a player or enemy
        if ((other.CompareTag("Player") || other.CompareTag("Enemy")))
        { 
            animator.SetTrigger("contact"); //trigger the contact animation in the animator component

            //play the spring sound effect 
            SoundManagerController.PlaySoundEffect("spring");

            //give viertical force to object 
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bounceForce); //apply the vertical force on the colliding object
        }
    }
}
