using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringController : MonoBehaviour
{
    public float horForce;
    public float verForce; 
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            float horizontalVelocity = collider.GetComponent<Rigidbody2D>().velocity.x; 
            collider.GetComponent<Rigidbody2D>().velocity = new Vector2(horForce * horizontalVelocity, verForce); 
        }
    }
}
