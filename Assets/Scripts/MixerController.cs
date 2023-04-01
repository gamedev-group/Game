using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; 

public class MixerController : MonoBehaviour
{
    public AudioMixer audioMixer; 

    void Awake()
    {
       audioMixer.SetFloat("MasterVolume", Mathf.Log10(0.0005f) * 20); 
       gameObject.SetActive(false); 
    }

    //function: SetVolume
    //purpose: set the volume of the music based on the slider 
    public void SetVolume(float sliderValue)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20); 
    }
}
