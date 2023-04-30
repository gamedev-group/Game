using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstLevel : MonoBehaviour
{
    public float changeTime; 
    void Update()
    {
        changeTime -= Time.deltaTime;

        if(changeTime <= 0)
        {
            if(GameManager.instance.currentLevel == 0)
            {
                GameManager.instance.IncreaseLevel(); 
            }
            else if(GameManager.instance.currentLevel == GameManager.instance.maxLevel)
            {
                SceneManager.LoadScene("MainMenu"); 
            }
        }
    }
}
