using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //transform component of the player in order for the camera to follow it 
    public Transform playerTransform; 

    [Tooltip("A smoothing value between 0 and 1.")]
    public float timeOffset; 
    public Vector2 offsetPos; 

    //min and max boundaries 
    public Transform leftBoundaryTransform;
    public Transform rightBoundaryTransform;
    public Transform upBoundaryTransform;
    public Transform downBoundaryTransform;

    private float leftBoundary; 
    private float rightBoundary;
    private float upBoundary; 
    private float downBoundary;

    private void Awake() {
        leftBoundary = leftBoundaryTransform.position.x;
        rightBoundary = rightBoundaryTransform.position.x;
        upBoundary = upBoundaryTransform.position.y;
        downBoundary = downBoundaryTransform.position.y;
    }

    private void LateUpdate()
    {
        if (playerTransform == null) return;

        //grab the current position and the target position
        Vector2 startPos = transform.position; 
        Vector2 targetPos = (Vector2)playerTransform.position + offsetPos; 

        //ensure that the target position stays within boundaries
        targetPos.x = Mathf.Clamp(targetPos.x, leftBoundary, rightBoundary);
        targetPos.y = Mathf.Clamp(targetPos.y, downBoundary, upBoundary); 

        float t = 1f - Mathf.Pow(1f - timeOffset, Time.deltaTime * 30);
        Vector2 newPos = Vector2.Lerp(startPos, targetPos, t); //lerping allows for the camera to smoothly slide towards player
        transform.position = new Vector3(newPos.x, newPos.y, -10); //z is -10 in order to capture all other sprites, which are at z = 0.
    }
}
