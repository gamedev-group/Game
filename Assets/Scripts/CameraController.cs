/***************************************************************
*file: CameraController.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose: The purpose of the `CameraController` class is to handle
*the movement of the in game camera. It follows the player's movements
*and ensures that the camera stays within predefined boundaries. It also
*provides a visual representation of the camera boundaries in the editor
*using the `OnDrawGizmos()` method.
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //transform component of the player in order for the camera to follow it 
    public Transform playerTransform; 

    [Tooltip("A smoothing value between 0 and 1.")]
    public float timeOffset; //time delay between camera following the player
    public Vector2 offsetPos; //offset from player position to adjust camera view

    //min and max boundaries 
    public Transform leftBoundaryTransform;
    public Transform rightBoundaryTransform;
    public Transform upBoundaryTransform;
    public Transform downBoundaryTransform;

    //store the boundary coordinates
    private float leftBoundary; 
    private float rightBoundary;
    private float upBoundary; 
    private float downBoundary;

    //function: Awake
    //purpose: Sets the 4 boundaries for the camera
    private void Awake() {
        //set the initial values of the boundaries 
        leftBoundary = leftBoundaryTransform.position.x;
        rightBoundary = rightBoundaryTransform.position.x;
        upBoundary = upBoundaryTransform.position.y;
        downBoundary = downBoundaryTransform.position.y;
    }

    //function:LateUpdate
    //pupose:update the camera position after all objects are moved in the frame
    private void LateUpdate()
    {
        if (playerTransform == null) return;

        //grab the current position and the target position
        Vector2 startPos = transform.position; 
        Vector2 targetPos = (Vector2)playerTransform.position + offsetPos; 

        //ensure that the target position stays within boundaries
        targetPos.x = Mathf.Clamp(targetPos.x, leftBoundary, rightBoundary);
        targetPos.y = Mathf.Clamp(targetPos.y, downBoundary, upBoundary);

        //interpolate between the current position and the target position
        float t = 1f - Mathf.Pow(1f - timeOffset, Time.deltaTime * 30); //update t to determine where to place the camera 
        Vector2 newPos = Vector2.Lerp(startPos, targetPos, t); //lerping allows for the camera to smoothly slide towards player
        transform.position = new Vector3(newPos.x, newPos.y, -10); //z is -10 in order to capture all other sprites, which are at z = 0.
    }

    //function: OnDrawGizmos
    //purpose: draw the camera boundaries in the editor 
    private void OnDrawGizmos() {
        //check if all the boundary transforms are set 
        if (leftBoundaryTransform == null || rightBoundaryTransform == null || upBoundaryTransform == null || downBoundaryTransform == null)
            return;

        //calculate the boundary values 
        leftBoundary = leftBoundaryTransform.position.x;
        rightBoundary = rightBoundaryTransform.position.x;
        upBoundary = upBoundaryTransform.position.y;
        downBoundary = downBoundaryTransform.position.y;

        float halfCameraHeight = Camera.main.orthographicSize; //get the height of the camera
        float halfCameraWidth = Camera.main.orthographicSize * Camera.main.aspect; //get the width of the camera based on aspect ratio

        float highestCameraPosition = upBoundary + halfCameraHeight; //get the highest possible camera position 
        float lowestCameraPosition = downBoundary - halfCameraHeight; //get the lowest possible camera position

        float leftmostCameraPosition = leftBoundary - halfCameraWidth; //get the leftmost possible camera position
        float rightmostCameraPosition = rightBoundary + halfCameraWidth; //get the rightmost possible camera position

        float centerX = leftmostCameraPosition + (rightmostCameraPosition - leftmostCameraPosition) / 2; //calculate the center x position of the camera
        float centerY = lowestCameraPosition + (highestCameraPosition - lowestCameraPosition) / 2; //calculate the center y position of the camera

        float sizeX = rightmostCameraPosition - leftmostCameraPosition; //calculate the width of the camera
        float sizeY = highestCameraPosition - lowestCameraPosition; //calculate the height of the camera

        Vector3 gizmoCenter = new Vector3(centerX, centerY, 0); //create a vector3 for the center of the gizmo
        Vector3 gizmoSize = new Vector3(sizeX, sizeY, 0); //create a vector3 for the size of the gizmo

        Gizmos.color = new Color(1, 0, 0, 0.5f); //set the gizmo color to red with transparency of 0.5
        Gizmos.DrawWireCube(gizmoCenter, gizmoSize); //draw the wireframe cube gizmo for the camera boundaries
    }
}
