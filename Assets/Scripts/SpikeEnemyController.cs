using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeEnemyController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    Rigidbody2D rb2d;
    
    public int contactDamage = 1; 

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(IsFacingRight())
        {
            rb2d.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //enemy gets into contact with an enemy 
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>(); 
            //pass in the damage to the player 
            player.TakeDamage(this.contactDamage); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb2d.velocity.x)), transform.localScale.y);
    }

    //function: IsFacingRight
    //purpose: check if the enemy is facing right or not 
    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

}
