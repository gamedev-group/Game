using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleknobController : MonoBehaviour
{
    //get the handle knob object 
    public RectTransform handleKnob; 

    // Start is called before the first frame update
    void Start()
    {
       handleKnob.anchorMax = new Vector2(1f, 1f); 
       handleKnob.anchorMin = new Vector2(0, 1f); 
    }

}
