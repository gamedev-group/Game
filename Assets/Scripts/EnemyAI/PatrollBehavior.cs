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
    private Vector3[] positions;
    [SerializeField]
    // The stopping distance away from the target position the object must reach before it advances to the next positon.
    // Set to some non-zero number to prevent the object from getting stuck in an infinate loop trying to reach it's target and overshooting
    private float stoppingDistance = 0.1f;
    // The movement speed of the object, in units/second
    [SerializeField]
    private float movementSpeed = 1f;

    private int positionIndex;

    // Start is called before the first frame update
    void Start()
    {
        positionIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToardsNextPosition();
        if (IsWithinRangeOfTarget())
        {
            IncrementTargetIndex();
        }
    }

    void MoveToardsNextPosition()
    {
        Vector3 targetPosition = positions[positionIndex];
        gameObject.transform.position = Vector3.MoveTowards(
                gameObject.transform.position,
                targetPosition,
                movementSpeed * Time.deltaTime);
    }

    bool IsWithinRangeOfTarget()
    {
        Vector3 targetPosition = positions[positionIndex];
        return Vector3.Distance(gameObject.transform.position, targetPosition) < stoppingDistance;
    }

    void IncrementTargetIndex()
    {
        positionIndex += 1;
        if (positionIndex == positions.Length)
        {
            positionIndex = 0;
        }
    }
}