using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillHandler : MonoBehaviour
{
    public RectTransform fill; 

    // Start is called before the first frame update
    void Start()
    {
        fill.anchorMax  = new Vector2(1, 1); 
    }
}
