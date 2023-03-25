using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //transform component of the player in order for the camera to follow it 
    public Transform playerTransform; 
    //move to the player but then slow down when camera gets close to it so we don't crash into the player 
    public float timeOffset; 
    public Vector2 offsetPos; 

    //min and max bounderies 
    public Vector2 minBoundary; 
    public Vector2 maxBoundary; 

    private void LateUpdate()
    {
        //check to make sure the player is on the scene 
        if(playerTransform != null)
        {
            //get the initial position of the camera 
            Vector2 startPos = transform.position; 

            //get the position of the player 
            Vector2 playerPos = playerTransform.position; 

            //add the offset to the position 
            //we can make the offset big so the camera will show a lot of environment to the front
            //so the player would be close to the left of the frame 
            //or the player could stay in the middle of the frame if the offset is set to 0 
            playerPos.x += offsetPos.x; 
            playerPos.y += offsetPos.y; 

            //make sure in the bounds of min and max (within the range)
            //basically we do not go where there is no background or platforms 
            //this means we do not go out of the frame 
            //if the target position (playerPos) is less than the min boundery, it will set the playerPos to min boundery 
            //if above max boundry, set it to max boundry 
            //if within it, then do not touch it 
            playerPos.x = Mathf.Clamp(playerPos, minBoundary.x, maxBoundary.x); 
            playerPos.y = Mathf.Clamp(playerPos, minBoundary.y, maxBoundary.y); 

        /*
            When t = 0, Vector3.Lerp(a, b, t) returns a.
            When t = 1, Vector3.Lerp(a, b, t) returns b.
            When t = 0.5, Vector3.Lerp(a, b, t) returns the point midway between a and b.
        */
            //if we change t, then we set an offset between where our camera center will be from the player 
            //so if we set the offset to 1, then we will directly go to the positon of the player 
            float t = 1f - Mathf.Pow(1f - timeOffset, Time.deltaTime * 30); 
            transform.position = Vector2.Lerp(startPos, playerPos, t); 
        }        
    }
}
