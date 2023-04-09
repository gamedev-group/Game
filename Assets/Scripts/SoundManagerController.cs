using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; 

public class SoundManagerController : MonoBehaviour
{
    public static AudioClip springSounfEffect;
    public static AudioClip spikeSounfEffect;
    public static AudioSource audioSrc; 

    // Start is called before the first frame update
    void Start()
    {
        springSounfEffect = Resources.Load<AudioClip>("springsound"); 
        spikeSounfEffect = Resources.Load<AudioClip>("spikesound"); 
        audioSrc = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySoundEffect(string clip)
    {   
        if(clip == "spring")
        {
            audioSrc.PlayOneShot(springSounfEffect); 
        }
        else if(clip == "spike")
        {
            audioSrc.PlayOneShot(spikeSounfEffect); 
        }
    }
}
