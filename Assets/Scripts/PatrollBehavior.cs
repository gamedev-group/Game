/***************************************************************
*file: PatrollBehavior.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose: Handle the movement of the enemy which is in a specific
*pattern set by the developer as they are parameters
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Causes the object this behavior is on to move between a set of points at constant speed
//Once the end of the set is reached, the object returns to the start point and the path loops
public class PatrollBehavior : MonoBehaviour
{
    // The list of points the object will move between
    // If the object is not at the first position when it is loaded, it will first move to that position before entering the loop
    [SerializeField]
    private Vector2[] positions;
    [SerializeField]
    // The stopping distance away from the target position the object must reach before it advances to the next positon.
    // Set to some non-zero number to prevent the object from getting stuck in an infinate loop trying to reach it's target and overshooting
    private float stoppingDistance = 1f;
    // The movement speed of the object, in units/second
    [SerializeField]
    private float movementSpeed = 1f;

    private int positionIndex;

    //function:Start
    //purpose: Start is called before the first frame update
    void Start()
    {
        positionIndex = 1;
    }

    //Function:Update
    //Purpose:Update is called once per frame
    void Update()
    {
        MoveToardsNextPosition();
        if (IsWithinRangeOfTarget())
        {
            IncrementTargetIndex();
        }
    }

    //function: MoveToardsNextPosition
    //purpose: go towards the next position set 
    void MoveToardsNextPosition()
    {
        // Set the next position as the target position
        Vector2 targetPosition = positions[positionIndex];

        // Move the object towards the target position at the specified movementSpeed
        gameObject.transform.position = Vector2.MoveTowards(
                gameObject.transform.position,
                targetPosition,
                movementSpeed * Time.deltaTime);
    }

    //function: IsWithinRangeOfTarget
    //purpose: check if the position of the enemy is within the range then return true or false 
    bool IsWithinRangeOfTarget()
    {
        // Set the next position as the target position
        Vector2 targetPosition = positions[positionIndex];

        // Return true if the distance to the target is less than the stopping distance, otherwise return false
        return Vector2.Distance(gameObject.transform.position, targetPosition) < stoppingDistance;
    }

    //function: IncrementTargetIndex
    //purpose: increasing the index based on the minimum and maximum positions 
    void IncrementTargetIndex()
    {
        // Increment the position index by 1
        positionIndex += 1;

        // If the position index is equal to the length of the positions array, set it back to 0 to loop
        if (positionIndex == positions.Length )
        {
            positionIndex = 0;
        }
    }

    //function: OnDrawGizmosSelected
    //purpose: Draws a sphere at each point in the positions array to help visualize the patrol path in the editor
    public void OnDrawGizmosSelected(){
        float baseSize = 0.5f;// Set the base size of the sphere to be drawn
        float sizeOffset = 0.1f;// Set the size offset between each sphere
        // Loop through each position in the positions array
        for (int i = 0; i<positions.Length; i++) {
            // Draw a sphere at the ith position in the positions array with a size that decreases based on its index
            Gizmos.DrawSphere(positions[i], baseSize-(i*sizeOffset));
        }
    }
}