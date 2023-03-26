using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // The speed at which the player moves left or right
    public float moveSpeed = 5f;

    // Rigidbody will be used to apply movement to player
    private Rigidbody2D rb2d;

    // Used to check whether player is currently touching the ground
    private bool isGrounded = false;
    //get the axis 
    private float keyboardAxis; 

    void Start()
    {
        // Get the Rigidbody2D component on the player object
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {    
        //handle the walking of the player 
        WalkHandler();
    }
    
    //function: WalkHandler 
    //purpose: this function controls the players walking motion which is to the left or right in the x direction 
    //      control this by the arrow keys on the keyboard 
    void WalkHandler()
    {
        // Get the horizontal input from the arrow keys or A and D keys
        keyboardAxis = Input.GetAxis("Horizontal"); 
        // Move the player left or right based on the horizontal input and moveSpeed
        rb2d.velocity = new Vector2(keyboardAxis * moveSpeed, rb2d.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player collides with an object tagged as "Ground", they are standing on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
