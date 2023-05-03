/***************************************************************
*file: MoveBackForth.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose: The purpose of this script is to allow an object to
*move back and forth between two points set by the left and right
*limits, and to reverse its direction when it reaches either limit.
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackForth : MonoBehaviour
{
    [SerializeField] Transform leftPoint, rightPoint;
    float leftEnd, rightEnd;
    [SerializeField] float moveSpeed = 1f;
    int dir = 1;
    Rigidbody2D rb2d;

    ///Function:Awake
    //purpose:Awake is called when the script instance is being loaded
    private void Awake()
    {
        //Get the Rigidbody2D component attached to the object
        rb2d = GetComponent<Rigidbody2D>();
        //get the right and left positions 
        leftEnd = leftPoint.position.x;
        rightEnd = rightPoint.position.x;
    }

    //Function:FixedUpdate
    //purpose:Called once every physics cycle
    private void FixedUpdate()
    {
        //Check if the enemy is at the right or left limit, and switch direction if it is.
        if ((rb2d.position.x > rightEnd && IsFacingRight()) || (rb2d.position.x < leftEnd && !IsFacingRight()))
            SwitchDirection();

        //Set the horizontal velocity of the enemy in the current direction.
        rb2d.velocity = new Vector2(moveSpeed * dir, rb2d.velocity.y);
    }

    //function: IsFacingRight
    //purpose: check if the enemy is facing right or not 
    private bool IsFacingRight()
    {
        //Check if the enemy's local scale on the x-axis is greater than zero, which means it is facing right.
        return transform.localScale.x > 0;
    }

    //function: SwitchDirection
    //purpose: changes the direction that the object will move in.
    private void SwitchDirection()
    {
        //Flip the enemy on the x-axis by reversing its local scale and reverse its movement direction.
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        dir *= -1;
    }

}
