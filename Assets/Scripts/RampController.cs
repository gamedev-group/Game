using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampController : MonoBehaviour
{
    public float speedBoost = 2f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            float horizontalVelocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity.x;
            float verticalVelocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity.y;
            print("Hor velocity is: " + horizontalVelocity);
            print("Ver velcocity is: " + verticalVelocity);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalVelocity * 40, speedBoost);
        }

    }

}
