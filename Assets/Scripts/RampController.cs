using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampController : MonoBehaviour
{
    public float horForce; 
    public float verForce;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Ramp")
        {
            collider.GetComponent<Rigidbody2D>().velocity = new Vector2(horForce, verForce); 
        }
    } 
}
