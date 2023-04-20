using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackForth : MonoBehaviour
{
    [SerializeField] Transform leftPoint, rightPoint;
    float leftEnd, rightEnd;
    [SerializeField] float moveSpeed = 1f;
    int dir = 1;
    Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        leftEnd = leftPoint.position.x;
        rightEnd = rightPoint.position.x;
    }

    private void FixedUpdate()
    {
        if ((rb2d.position.x > rightEnd && IsFacingRight()) || (rb2d.position.x < leftEnd && !IsFacingRight()))
            SwitchDirection();

        rb2d.velocity = new Vector2(moveSpeed * dir, rb2d.velocity.y);
    }

    //function: IsFacingRight
    //purpose: check if the enemy is facing right or not 
    private bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    //function: SwitchDirection
    //purpose: changes the direction that the object will move in.
    private void SwitchDirection()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        dir *= -1;
    }

}
