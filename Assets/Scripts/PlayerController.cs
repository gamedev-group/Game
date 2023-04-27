using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // The speed at which the player moves left or right
    public float moveSpeed = 5f;
    //audio source
    public AudioSource wheelchairSound; 
    // Rigidbody will be used to apply movement to player
    private Rigidbody2D rb2d;
    private bool facingRight = true;
    

    void Start()
    {
        // Get the Rigidbody2D component on the player object
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {    
        //handle the walking of the player 
        WalkHandler();

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.instance.hasMagnet = false; 
        }
    }
    
    //function: WalkHandler 
    //purpose: this function controls the players walking motion which is to the left or right in the x direction 
    //      control this by the arrow keys on the keyboard 
    void WalkHandler()
    {
        // Get the horizontal input from the arrow keys or A and D keys
        float keyboardAxis = Input.GetAxis("Horizontal");
        float inputAxis = Input.GetAxisRaw("Horizontal");

        if ((inputAxis > 0 && !facingRight) || (inputAxis < 0 && facingRight)) {
            facingRight = !facingRight;

            // In order for the freeze ray to function properly this is we need to rotate player
            //transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
            transform.Rotate(0f, 180f, 0f);
        }

        if(inputAxis != 0)
        {
            wheelchairSound.enabled = true; 
        }
        else
        {
            wheelchairSound.enabled = false; 
        }

        // Move the player left or right based on the horizontal input and moveSpeed
        rb2d.velocity = new Vector2(keyboardAxis * moveSpeed, rb2d.velocity.y);
    }
}
