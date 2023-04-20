using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block: MonoBehaviour
{
    Rigidbody2D rb;

    bool hasTarget;
    Vector3 targetPos; 

    public float speed = 5f; 

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(hasTarget)
        {
            //the direction moving 
            Vector3 targetDir = (targetPos - transform.position).normalized; 
            rb.velocity = new Vector2(targetDir.x, targetDir.y) * speed; 
        }
    }

    public void SetTarget(Vector2 pos, bool check)
    {
        targetPos = pos;
        hasTarget = check; 
    }

    public void SetHasTarget(bool check)
    {
        hasTarget = check; 
    }
}