using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; 

public class StartSound : MonoBehaviour
{
    public AudioSource s1; 

    // Start is called before the first frame update
    void Start()
    {
        s1 = GetComponent<AudioSource>(); 
        s1.Play(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
