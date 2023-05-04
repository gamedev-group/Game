/***************************************************************
*file: FillHandler.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/04/2023
*
*purpose:  This script is responsible for handling the fill part 
*of the volume slider. 
*
****************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillHandler : MonoBehaviour
{
    //get the rect transform component of fill game object 
    public RectTransform fill; 

    // Start is called before the first frame update
    void Start()
    {
        //fill the volume slider to its max 
        fill.anchorMax  = new Vector2(1, 1); 
    }
}
