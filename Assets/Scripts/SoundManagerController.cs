using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; 

public class SoundManagerController : MonoBehaviour
{
    public static AudioClip springSounfEffect;
    public static AudioSource audioSrc; 

    // Start is called before the first frame update
    void Start()
    {
        springSounfEffect = Resources.Load<AudioClip>("springsound"); 
        audioSrc = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySoundEffect(string clip)
    {   
        if(clip == "springsound")
        {
            audioSrc.PlayOneShot(springSounfEffect); 
        }
    }
}
