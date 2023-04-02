using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFlag : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        print("Goal!");
    }
}
