using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Causes UI elements this behavior is attached to to change their position as a reaction to the mouse position in screen

public class UIParalaxLayer : MonoBehaviour
{

    [SerializeField]
    private float translationAmount = 0.0f;

    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.anchoredPosition3D = getAdjustedMousePosition() * translationAmount;
    }

    // Get the position of the mouse adjusted so that (-1,-1) is the bottom left corner of the screen and (1,1) is the top right
    Vector3 getAdjustedMousePosition()
    {
        Vector3 rawMousePosition = Input.mousePosition;

        float adjustedXPosition = ((rawMousePosition.x / Screen.width) * 2f) - 1f;
        float adjustedYPosition = ((rawMousePosition.y / Screen.height) * 2f) - 1f;

        return new Vector3(adjustedXPosition, adjustedYPosition, 0f);
    }
}
