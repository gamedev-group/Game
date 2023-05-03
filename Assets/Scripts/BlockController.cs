/***************************************************************
*file: BlockController.cs
*author: Group
*class: CS 4700 – Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose: This script is attached to a block object in the game and detects collisions with other objects
*The purpose of this script is to detect collisions with the "Spike" object and destroy the block if it collides with it
*
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    //function: OnCollisionEnter2D
    //purpose: detect collision with the ramp
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object we collided with has the tag "Spike"
        if (collision.gameObject.tag == "Spike")
        {
            // If it does, destroy the Rigidbody2D component of this block object
            Destroy(this.GetComponent<Rigidbody2D>()); 
        }

    }
}
