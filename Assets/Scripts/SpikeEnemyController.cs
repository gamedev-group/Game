using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeEnemyController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    Rigidbody2D rb2d;

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
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb2d.velocity.x)), transform.localScale.y);
    }


    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

}
