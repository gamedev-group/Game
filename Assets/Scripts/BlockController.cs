using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    //function: OnCollisionEnter2D
    //purpose: detect collision with the ramp
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Spike")
        {
            Destroy(this.GetComponent<Rigidbody2D>()); 
        }

    }
}
