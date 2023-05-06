/***************************************************************
*file: HandleknobController.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/04/2023
*
*purpose:  This script is responsible for handling the handle knob 
*of the volume slider. 
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleknobController : MonoBehaviour
{
    //get the handle knob object 
    public RectTransform handleKnob; 

    //function: Start
    //purpose: Sets the min and max anchor points for the volume handle knobs
    void Start()
    {
        //adjust the min and max so the knob is at the max position 
       handleKnob.anchorMax = new Vector2(1f, 1f); 
       handleKnob.anchorMin = new Vector2(0, 1f); 
    }

}
