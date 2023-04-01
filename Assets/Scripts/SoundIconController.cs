using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundIconController : MonoBehaviour
{
    public GameObject obj; 

    private static int countClick = 0; 

    public void SoundButtonClicked()
    {
        ++countClick;
        if(countClick % 2 != 0)
        {
            obj.SetActive(true); 
        }
        else
        {   
            obj.SetActive(false); 
        }
        print(countClick); 
    }
}
