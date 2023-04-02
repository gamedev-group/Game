using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemIcon : MonoBehaviour
{
    public Image itemDisplay;
    public TextMeshProUGUI quantityDisplay;
    public Image selectedBackground;

    void OnEnable() {
        DeselectBackground();
    }

    public void SelectBackground() {
        selectedBackground.gameObject.SetActive(true);
    }

    public void DeselectBackground() {
        selectedBackground.gameObject.SetActive(false);
    }
}
