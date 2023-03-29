using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // The speed at which the player moves left or right
    public float moveSpeed = 5f;

    // Rigidbody will be used to apply movement to player
    private Rigidbody2D rb2d;

    private bool facingRight = true;
    
    private int currentHealth = 1; 

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
    
    //function: TakeDamage
    //purpose: this function's purpose is to determine how much damage the player will take 
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth == 0)
        {
            Destroy(gameObject); 
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
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
        }

        // Move the player left or right based on the horizontal input and moveSpeed
        rb2d.velocity = new Vector2(keyboardAxis * moveSpeed, rb2d.velocity.y);
    }
}
