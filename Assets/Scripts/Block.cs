/***************************************************************
*file: Block.cs
*author: Group
*class: CS 4700 – Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose: This program is responsivle for controlling the movement of
*the in game blocks
*
****************************************************************/

// Import necessary libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define the Block class which inherits from MonoBehaviour
public class Block : MonoBehaviour
{
    // Instance Variables
    private Rigidbody2D rb; // Rigidbody2D component of the block
    private bool hasTarget; // Whether or not the block has a target position to move towards
    private Vector3 targetPos; // Target position for the block to move towards

    public float speed = 5f; // Speed at which the block moves

    //function: Awake
    //purpose: Set the rigidbody2D component of the block
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //function: FixedUpdate
    //purpose: Move the block towards the target position if the block has a target position and the rigidbody2D component is not null
    private void FixedUpdate()
    {
        if (hasTarget && rb != null)
        {
            // Calculate the direction to move towards
            Vector3 targetDir = (targetPos - transform.position).normalized;
            // Set the velocity of the rigidbody2D component of the block to move it in the calculated direction at the set speed
            rb.velocity = new Vector2(targetDir.x, targetDir.y) * speed;
        }
    }

    //function: Update
    //purpose: If the 'R' key is pressed and the tag of the block is not "Block", destroy the rigidbody2D component of the block
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.instance.hasMagnet = false;
            if (rb != null && this.tag != "Block")
            {
                Destroy(this.GetComponent<Rigidbody2D>());
            }
        }
    }

    //function: SetTarget
    //purpose: Set the target position of the block and the hasTarget value
    public void SetTarget(Vector2 pos, bool check)
    {
        targetPos = pos;
        hasTarget = check;
    }

    //function: SetHasTarget
    //purpose: Set the hasTarget value
    public void SetHasTarget(bool check)
    {
        hasTarget = check;
    }
}
