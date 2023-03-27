using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacer : MonoBehaviour
{
    public GameObject plank;
    public LayerMask groundLayer;
    public Transform placeTransform;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D hit = Physics2D.Raycast(placeTransform.position, Vector2.down, Mathf.Infinity, groundLayer);
            if (hit.collider != null)
            {
                GameObject spawnedObj = Instantiate(plank, hit.point, Quaternion.identity);
            }
        }
    }
}
