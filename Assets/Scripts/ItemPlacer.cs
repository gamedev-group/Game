using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacer : MonoBehaviour
{
    //place whatever scriptable objects the player will use here
    public List<PlaceableScriptableObject> objectList = new List<PlaceableScriptableObject>();
    public List<PlaceableScriptableObject> selectionList = new List<PlaceableScriptableObject>();
    
    //store the items, and how much the player can use
    private Dictionary<PlaceableScriptableObject, int> objectDictionary = new Dictionary<PlaceableScriptableObject, int>();
    
    //this event is invoked on start, when the dictionary is completed.
    public delegate void OnItemDictionaryGenerated(Dictionary<PlaceableScriptableObject, int> dictionary); 
    public static OnItemDictionaryGenerated signalDictionary;
    
    //this event is invoked when the player uses an item.
    public delegate void OnItemUsed(PlaceableScriptableObject item, int newQuantity); 
    public static OnItemUsed itemUsed;

    //this event is invoked when the player changes their currently selected item.
    public delegate void OnSelectedItemChanged(PlaceableScriptableObject item); 
    public static OnSelectedItemChanged selectionChanged;
    public LayerMask groundLayer;
    public Transform placeTransform;
    private int index = 0;
    private PlaceableScriptableObject selected;
    

    void Start() {
        //read through each item in object list
        foreach (PlaceableScriptableObject obj in objectList) {
            if (objectDictionary.ContainsKey(obj))
                objectDictionary[obj]++;
            else
                objectDictionary.Add(obj, 1);
                selectionList.Add(obj);
        }
        //object dictionary is finished
        //selection list now contains unique elements
        signalDictionary(objectDictionary);

        selected = selectionList[index];
        selectionChanged(selected);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E)) {
            //Q <-    E ->
            if (Input.GetKeyDown(KeyCode.Q))
                index--;
            else if (Input.GetKeyDown(KeyCode.E))
                index++;
            
            index = Modulo(index, selectionList.Count); //the object list is circular
            selected = selectionList[index];
            selectionChanged(selected);

            //TODO: Implement this as UI.
            print("Selected: " + selected.itemName);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //shoot a raycast downwards in front of the player towards the ground
            RaycastHit2D hit = Physics2D.Raycast(placeTransform.position, Vector2.down, Mathf.Infinity, groundLayer);
            if (hit.collider != null && hit.normal.Equals(Vector2.up) && objectDictionary[selected] != 0)
            {
                GameObject spawnedObj = Instantiate(selected.prefab, hit.point, Quaternion.identity);
                
                //if we are facing to the left, rotate the object 180 degrees on the y to reverse its direction.
                if (transform.localScale.x < 0) {
                    spawnedObj.transform.Rotate(new Vector3(0, 180, 0));
                }

                //TODO: Remove the selected item from the list.
                objectDictionary[selected]--;
                itemUsed(selected, objectDictionary[selected]);
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
