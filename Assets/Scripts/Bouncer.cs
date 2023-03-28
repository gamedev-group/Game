using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public float bounceForce;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bounceForce);
        }

        // TODO: Figure out why spring doesn't launch enemy
        if (other.CompareTag("Enemy"))
        {
            print("Hit Enemy");
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bounceForce);
        }
    }
}
