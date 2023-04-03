using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFlag : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other) {
        //flag collides with the player -> player reaching the goal 
        if(other.gameObject.tag == "Player")
        {
            GameManager.instance.won = true; 
        }
    }
}
