using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampController : MonoBehaviour
{
    public float speedBoost = 20f;

    void OnCollisionStay2D(Collision2D collision)
    {
        float horizontalVelocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity.x;
        print("Horizantal:" + horizontalVelocity);
        float verticalVelocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity.y;
        print("Vertical:" + verticalVelocity);
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speedBoost * horizontalVelocity, verticalVelocity * 2);


    }

}
