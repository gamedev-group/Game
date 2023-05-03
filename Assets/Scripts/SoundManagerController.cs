/***************************************************************
*file: SoundManagerController.cs
*author: Group
*class: CS 4700- Game Development
*assignment: Program 4
*date last modified: 5/03/2023
*
*purpose:This script is responsible for managing sound effects in the game.
*It contains audio clips for various sound effects and a static function that
*plays different sound effects based on the input parameter.
*
****************************************************************/
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
    public static AudioClip magnetSoundEffect;
    public static AudioClip freezeRaySoundEffect;

    //function: Awake
    //purpose: This function is called when the script instance is
    //being loaded and gets audio clips for sound effects
    void Awake()
    {
        springSounfEffect = Resources.Load<AudioClip>("springsound"); 
        spikeSounfEffect = Resources.Load<AudioClip>("spikesound"); 
        levComSoundEffect = Resources.Load<AudioClip>("levelwin"); 
        buttonClickSoundEffect = Resources.Load<AudioClip>("buttonpressed"); 
        enemyHitSoundEffect = Resources.Load<AudioClip>("enemyhit"); 
        plankSoundEffect = Resources.Load<AudioClip>("plank"); 
        magnetSoundEffect = Resources.Load<AudioClip>("magnet"); 
        freezeRaySoundEffect = Resources.Load<AudioClip>("freezeray"); 
        audioSrc = GetComponent<AudioSource>(); 
    }

    //function: PlaySoundEffect
    //purpose: play different sound effects based on the parameter 
    public static void PlaySoundEffect(string clip)
    {
        //check to see which sound effect is requested by the action then play the corresponding one 
        if (clip == "spring")
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
        else if(clip == "magnet")
        {
            audioSrc.PlayOneShot(magnetSoundEffect);
        } 
        else if(clip == "freezeray")
        {
            audioSrc.PlayOneShot(freezeRaySoundEffect); 
        }
    }
}
