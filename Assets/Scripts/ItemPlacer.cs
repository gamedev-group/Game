﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacer : MonoBehaviour
{
    public List<PlaceableScriptableObject> objectList = new List<PlaceableScriptableObject>();
    public LayerMask groundLayer;
    public Transform placeTransform;
    private int index = 0;
    private PlaceableScriptableObject selected;

    void Awake() {
        selected = objectList[index];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E)) {
            //Q <-    E ->
            if (Input.GetKeyDown(KeyCode.Q))
                index--;
            else if (Input.GetKeyDown(KeyCode.E))
                index++;
            
            index = Modulo(index, objectList.Count); //the object list is circular
            selected = objectList[index];

            //TODO: Implement this as UI.
            print("Selected: " + selected.itemName);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //shoot a raycast downwards in front of the player towards the ground
            RaycastHit2D hit = Physics2D.Raycast(placeTransform.position, Vector2.down, Mathf.Infinity, groundLayer);
            if (hit.collider != null && hit.normal.Equals(Vector2.up))
            {
                GameObject spawnedObj = Instantiate(selected.prefab, hit.point, Quaternion.identity);
                
                //if we are facing to the left, rotate the object 180 degrees on the y to reverse its direction.
                if (transform.localScale.x < 0) {
                    spawnedObj.transform.Rotate(new Vector3(0, 180, 0));
                }

                //TODO: Remove the selected item from the list.
            }
        }
    }

    //name: Modulo
    //purpose: unlike in other languages, the % operator in C# is for remainder operations, not modulo operations.
    //unlike remainder operations, modulo operations will "wrap" when a is a negative number.
    int Modulo(int a, int b) {
        return (a % b + b) % b;
    }
}
