/***************************************************************
*file: ItemPlacer.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose: This is a C# script for a game that allows the player
*to place items on the ground. The script defines a structure for
*items, an array of items that the player can place, and a dictionary
*for storing the items that the player has and the quantity that they
*have. The script also includes functions for changing the selected
*item, placing the selected item on the ground, and signaling when an
*item has been used.
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacer : MonoBehaviour
{
    //define the structure for the item
    [System.Serializable]
    public struct Item
    {
        public PlaceableScriptableObject item; //the item to be placed
        public int quantity; //the amount of items that the player can place
    }

    // An array of items that the player can place.
    public Item[] objectList;

    // A dictionary for storing the items that the player has and the quantity that they have.
    private Dictionary<PlaceableScriptableObject, int> objectDictionary = new Dictionary<PlaceableScriptableObject, int>();

    // This delegate is used to signal that the item dictionary has been generated.
    public delegate void OnItemDictionaryGenerated(Dictionary<PlaceableScriptableObject, int> dictionary); 
    public static OnItemDictionaryGenerated signalDictionary;

    // This delegate is used to signal that an item has been used.
    public delegate void OnItemUsed(PlaceableScriptableObject item, int newQuantity); 
    public static OnItemUsed itemUsed;

    // This delegate is used to signal that the player has changed their selected item.
    public delegate void OnSelectedItemChanged(PlaceableScriptableObject item); 
    public static OnSelectedItemChanged selectionChanged;

    // A layer mask for the ground layer.
    public LayerMask groundLayer;

    // The transform for the item placement.
    public Transform placeTransform;

    // The index of the selected item in the object list.
    private int index = 0;

    // The currently selected item.
    private PlaceableScriptableObject selected;

    // The time that the magnet was activated.
    public static float magnetStartTime;


    //function:Awake
    //purpose: Iterate through each item in the object list and add it to the dictionary.
    void Awake() {
        // Iterate through each item in the object list and add it to the dictionary.
        foreach (Item i in objectList) {
            objectDictionary.Add(i.item, i.quantity);
        }
    }

    //function: Start
    //purpose: signal that object dictionanry is create and then set selected item as first item
    void Start() {
        // Signal that the object dictionary has been generated.
        signalDictionary(objectDictionary);

        // Set the selected item to the first item in the object list.
        selected = objectList[index].item;
        selectionChanged(selected);
    }


    //function:Update
    //purpose: Every frame checks to see if player has selected a diffrent items and checks if
    //player wants to use item. If they do use the item decease the number of items in player inventory
    // and activate the item
    [System.Obsolete]
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { //If the player hit the 1 key
            //set the selected item to the first
            index = 0;
            UpdateItemIndex();
        } 
        //If the player hit the 2 key and there are at least 2 unique objects available
        else if (Input.GetKeyDown(KeyCode.Alpha2) && objectList.Length >= 2) {
            //set the selected item to the second
            index = 1;
            UpdateItemIndex();
        }
        //If the player hit the 3 key and there are at least 3 unique objects available
        else if (Input.GetKeyDown(KeyCode.Alpha3) && objectList.Length >= 3) {
            //set the selected item to the third
            index = 2;
            UpdateItemIndex();
        }
        //If the player hit the 4 key and there are at least 4 unique objects available
        else if (Input.GetKeyDown(KeyCode.Alpha4) && objectList.Length >= 4) {
            //set the selected item to the fourth
            index = 3;
            UpdateItemIndex();
        }
        //We don't have to check any other numerical keys since the most unique items you can have are 4.

        // Check if the player has pressed the Q or E keys to change the selected item.
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E)) {
            // If the player has pressed Q, decrement the index.
            // If the player has pressed E, increment the index.
            //Q <-    E ->
            if (Input.GetKeyDown(KeyCode.Q))
                index--;
            else if (Input.GetKeyDown(KeyCode.E))
                index++;

            UpdateItemIndex();
        }

        // Check if the player has pressed the spacebar to activate the item.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Shoot a raycast downwards from the player's position towards the ground
            RaycastHit2D hit = Physics2D.Raycast(placeTransform.position, Vector2.down, 1.0f, groundLayer);
            
            // Check if the raycast hit an object on the ground and the hit normal is facing upwards.
            bool canPlace = (hit.collider != null && hit.normal.Equals(Vector2.up));

            // Declare a variable to store the object that will be spawned.
            bool needsToPlace = selected.requiresGround;
            GameObject spawnedObj;

            if(GameManager.instance.infiniteItems)
            {
                if (canPlace)
                {
                    // If the selected item is a plank, play a sound effect.
                    if (selected.itemName == "Plank")
                    {
                        SoundManagerController.PlaySoundEffect("plank");
                    }

                    // Print the location where the item will be placed.
                    print("Floor Hit" + hit.point);

                    // If the selected item is a freeze ray, spawn the object at Vector3.zero.
                    if (selected.itemName == "Freeze Ray" || selected.itemName == "Magnet Ray")
                    {
                        spawnedObj = Instantiate(selected.prefab, Vector3.zero, Quaternion.identity);
                    }
                    else
                    {
                        // Spawn the object at the hit point with no rotation.
                        spawnedObj = Instantiate(selected.prefab, hit.point, Quaternion.identity);

                        // If the player is facing to the left, rotate the object 180 degrees on the y to reverse its direction.
                        if (((int)transform.rotation.eulerAngles.y) == 180)
                        {
                            spawnedObj.transform.Rotate(new Vector3(0, 180, 0));
                        } else {
                            print(transform.rotation.eulerAngles.y);
                        }
                    }
                }
                else if (!needsToPlace) {
                    //check if the selected item is freeze ray or magnet ray 
                    // If the selected item is a freeze ray or magnet ray, spawn the object at Vector3.zero.
                    if (selected.itemName == "Freeze Ray" || selected.itemName == "Magnet Ray")
                    {
                        spawnedObj = Instantiate(selected.prefab, Vector3.zero, Quaternion.identity);
                    }
                    else
                    {
                        print("magnet"); 
                        // Spawn the object at the player's position with no rotation.
                        spawnedObj = Instantiate(selected.prefab, placeTransform.position, Quaternion.identity);
                    }

                    // If the player is facing to the left and the selected item is not a freeze ray or magnet ray, rotate the object 180 degrees on the y to reverse its direction.
                    if (transform.rotation.eulerAngles.y == 180)
                    {
                        if (selected.itemName != "Freeze Ray" || selected.itemName != "Magnet Ray")
                        {
                            spawnedObj.transform.Rotate(new Vector3(0, 180, 0));
                        }
                    }
                }
            }
            else
            {
                // If the item can be placed and the player has at least one of the selected item in their inventory:
                if (canPlace && objectDictionary[selected] != 0)
                {
                    // If the selected item is a plank, play a sound effect.
                    if (selected.itemName == "Plank")
                    {
                        SoundManagerController.PlaySoundEffect("plank");
                    }

                    // Print the location where the item will be placed.
                    print("Floor Hit" + hit.point);

                    // If the selected item is a freeze ray, spawn the object at Vector3.zero.
                    if (selected.itemName == "Freeze Ray" || selected.itemName == "Magnet Ray")
                    {
                        spawnedObj = Instantiate(selected.prefab, Vector3.zero, Quaternion.identity);
                    }
                    else
                    {
                        // Spawn the object at the hit point with no rotation.
                        
                        spawnedObj = Instantiate(selected.prefab, hit.point, Quaternion.identity);

                        // If the player is facing to the left, rotate the object 180 degrees on the y to reverse its direction.
                        if (((int)transform.rotation.eulerAngles.y) == 180)
                        {
                            spawnedObj.transform.Rotate(new Vector3(0, 180, 0));
                        } else {
                            print(transform.rotation.eulerAngles.y);
                        }
                    }

                    // Decrease the amount of selected item in the player's inventory by 1.
                    objectDictionary[selected]--;

                    // Call the itemUsed function with the selected item and the new amount in the player's inventory as parameters.
                    itemUsed(selected, objectDictionary[selected]);
                }
                // If the item doesn't require a ground to be placed and the player has at least one of the selected item in their inventory:
                else if (!needsToPlace && objectDictionary[selected] != 0) {
                    //check if the selected item is freeze ray or magnet ray 
                    // If the selected item is a freeze ray or magnet ray, spawn the object at Vector3.zero.
                    if (selected.itemName == "Freeze Ray" || selected.itemName == "Magnet Ray")
                    {
                        spawnedObj = Instantiate(selected.prefab, Vector3.zero, Quaternion.identity);
                    }
                    else
                    {
                        // Spawn the object at the player's position with no rotation.
                        spawnedObj = Instantiate(selected.prefab, placeTransform.position, Quaternion.identity);
                    }

                    // If the player is facing to the left and the selected item is not a freeze ray or magnet ray, rotate the object 180 degrees on the y to reverse its direction.
                    if (transform.rotation.eulerAngles.y == 180)
                    {
                        if (selected.itemName != "Freeze Ray" || selected.itemName != "Magnet Ray")
                        {
                            spawnedObj.transform.Rotate(new Vector3(0, 180, 0));
                        }
                    }
                    // Decrease the amount of selected item in the player's inventory by 1.
                    objectDictionary[selected]--;

                    // Call the itemUsed function with the selected item and the new amount in the player's inventory as parameters.
                    itemUsed(selected, objectDictionary[selected]);
                }
            }
        }
    }

    //name: Modulo
    //purpose: unlike in other languages, the % operator in C# is for remainder operations, not modulo operations.
    //unlike remainder operations, modulo operations will "wrap" when a is a negative number.
    int Modulo(int a, int b) {
        return (a % b + b) % b;
    }

    //name: UpdateItemIndex
    //purpose: this will be called whenever the user hits a key that changes the currently selected item. It is placed
    //into a method to avoid repetition.
    void UpdateItemIndex() {
        // Set the index to the appropriate value within the object list.
        // Note: the object list is circular
        index = Modulo(index, objectList.Length); 

        // Set the selected item to the item at the selected index.
        selected = objectList[index].item;

        // Signal that the selected item has been changed.
        selectionChanged(selected);

        // Print the name of the selected item to the console.
        print("Selected: " + selected.itemName);
    }
}
