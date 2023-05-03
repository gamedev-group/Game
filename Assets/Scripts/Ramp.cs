/***************************************************************
*file: Ramps.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose:  The purpose of this script is to control the behavior
*of a ramp GameObject in the game, including its movement and target
*positioning.
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp: MonoBehaviour
{
    Rigidbody2D rb;

    bool hasTarget;
    Vector3 targetPos; 

    public float speed = 5f;

    ///Function:Awake
    //purpose:Awake is called when the script instance is being loaded
    private void Awake()
    {
        //get the Rigidbody2D component from the game object this script is attached to
        rb = GetComponent<Rigidbody2D>(); 
    }

    //Function:FixedUpdate
    //purpose:Called once every physics cycle
    private void FixedUpdate()
    {
        if(hasTarget)
        {
            //determine the direction to move towards the target position
            Vector3 targetDir = (targetPos - transform.position).normalized;
            //set the velocity of the Rigidbody2D to move towards the target position at a fixed speed
            rb.velocity = new Vector2(targetDir.x, targetDir.y) * speed; 
        }
    }

    //function: SetTarget
    //purpose: set the target position and hasTarget flag of the ramp GameObject
    public void SetTarget(Vector2 pos, bool check)
    {
        targetPos = pos;
        hasTarget = check; 
    }

    //function: SetHasTarget
    //purpose: set the hasTarget flag of the ramp GameObject
    public void SetHasTarget(bool check)
    {
        hasTarget = check; 
    }
}
