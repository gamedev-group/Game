using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; 

public class SoundManagerController : MonoBehaviour
{
    public static AudioSource audioSrc; 
    // audio clips 
    public static AudioClip springSounfEffect;
    public static AudioClip spikeSounfEffect;
    public static AudioClip levComSoundEffect; 
    public static AudioClip buttonClickSoundEffect; 
    public static AudioClip enemyHitSoundEffect;
    public static AudioClip plankSoundEffect;
    public static AudioClip wheelchairSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        springSounfEffect = Resources.Load<AudioClip>("springsound"); 
        spikeSounfEffect = Resources.Load<AudioClip>("spikesound"); 
        levComSoundEffect = Resources.Load<AudioClip>("levelwin"); 
        buttonClickSoundEffect = Resources.Load<AudioClip>("buttonpressed"); 
        enemyHitSoundEffect = Resources.Load<AudioClip>("enemyhit"); 
        plankSoundEffect = Resources.Load<AudioClip>("plank"); 
        wheelchairSoundEffect = Resources.Load<AudioClip>("wheelchair"); 
        audioSrc = GetComponent<AudioSource>(); 
    }

    //function: PlaySoundEffect
    //purpose: play different sound effects based on the parameter 
    public static void PlaySoundEffect(string clip)
    {   
    //check to see which sound effect is requested by the action then play the corresponding one 
        if(clip == "spring")
        {
            audioSrc.PlayOneShot(springSounfEffect); 
        }
        else if(clip == "spike")
        {
            audioSrc.PlayOneShot(spikeSounfEffect); 
        }
        else if(clip == "levcomp")
        {
            audioSrc.PlayOneShot(levComSoundEffect); 
        }
        else if(clip == "buttonclick")
        {
            audioSrc.PlayOneShot(buttonClickSoundEffect); 
        }
        else if(clip == "enemyhit")
        {
            audioSrc.PlayOneShot(enemyHitSoundEffect); 
        }
        else if(clip == "plank")
        {
            audioSrc.PlayOneShot(plankSoundEffect); 
        }
    }
}
