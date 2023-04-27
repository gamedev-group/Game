using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacer : MonoBehaviour
{
    [System.Serializable]
    public struct Item {
        public PlaceableScriptableObject item;
        public int quantity;
    }
    public Item[] objectList;

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
    
    public static float magnetStartTime; 

    void Awake() {
        //read through each item in object list
        //TODO: This doesn't really split it correctly
        foreach (Item i in objectList) {
            objectDictionary.Add(i.item, i.quantity);
        }
    }

    void Start() {
        //object dictionary is finished
        //selection list now contains unique elements
        signalDictionary(objectDictionary);

        selected = objectList[index].item;
        selectionChanged(selected);
    }

    [System.Obsolete]
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E)) {
            //Q <-    E ->
            if (Input.GetKeyDown(KeyCode.Q))
                index--;
            else if (Input.GetKeyDown(KeyCode.E))
                index++;
            
            index = Modulo(index, objectList.Length); //the object list is circular
            selected = objectList[index].item;
            selectionChanged(selected);

            //TODO: Implement this as UI.
            print("Selected: " + selected.itemName);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(selected.itemName != "Magnet")
            {
                //shoot a raycast downwards in front of the player towards the ground 
                RaycastHit2D hit = Physics2D.Raycast(placeTransform.position, Vector2.down, 1.0f, groundLayer);
                bool canPlace = (hit.collider != null && hit.normal.Equals(Vector2.up));
                bool needsToPlace = selected.requiresGround;
                if (canPlace  && objectDictionary[selected] != 0)
                {
                    if(selected.itemName == "Plank")
                    {
                        SoundManagerController.PlaySoundEffect("plank");
                    }

                    GameObject spawnedObj = Instantiate(selected.prefab, hit.point , Quaternion.identity);
                    
                    //if we are facing to the left, rotate the object 180 degrees on the y to reverse its direction.
                    if (transform.rotation.eulerAngles.y == 180) {
                        spawnedObj.transform.Rotate(new Vector3(0, 180, 0));
                    }

                    objectDictionary[selected]--;
                    itemUsed(selected, objectDictionary[selected]);
                }
                else if (!needsToPlace  && objectDictionary[selected] != 0) {
                    GameObject spawnedObj = Instantiate(selected.prefab, placeTransform.position, Quaternion.identity);

                    //if we are facing to the left, rotate the object 180 degrees on the y to reverse its direction.
                    if (transform.rotation.eulerAngles.y == 180) {
                        spawnedObj.transform.Rotate(new Vector3(0, 180, 0));
                    }

                    objectDictionary[selected]--;
                    itemUsed(selected, objectDictionary[selected]);
                }
            }
            else
            {
                GameManager.instance.hasMagnet = true; 
                GameManager.instance.hasReleased = false; 
                magnetStartTime = Time.time;

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
