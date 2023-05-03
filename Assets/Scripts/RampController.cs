/***************************************************************
*file: RampController.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose:  The purpose of this script is to control the behavior
*of the speed boost given by the ramp GameObject in the game.
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampController : MonoBehaviour
{
    public float speedBoost = 2f;

    // function: OnCollisionEnter2D
    // purpose: Detects collision with the ramp when the player object hits it and applies a speed boost to the player.
    void OnCollisionEnter2D(Collision2D collision)
    {
        // checks if the object that collided with the ramp has the "Player" tag
        if (collision.gameObject.tag == "Player")
        {
            // gets the horizontal and vertical velocity of the player object before the speed boost
            float horizontalVelocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity.x;
            float verticalVelocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity.y;

            // prints the player's velocity for debugging purposes
            print("Hor velocity is: " + horizontalVelocity);
            print("Ver velcocity is: " + verticalVelocity);

            // sets the new velocity of the player object to a higher speed in the Y direction
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalVelocity * 40, speedBoost);
        }

    }

}
