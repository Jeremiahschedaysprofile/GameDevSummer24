using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable] // this allows this sound to appear in the inspector window 

public class Sound
{
    public string name; // the reference name for this sound effect

    public AudioClip audioClip; // the audio clip assigned to this sound 

    //[Range(0, 1f)]

    public float volume = 1; // the volume of the sound effect 

     public float pitch = 1; // the pithc of the sound effect

     public bool loop = false; // a flag weather or not this sound loops or not

     [HideInInspector] // hide this member becuase AudioManager will handle it for us

     public AudioSource audioSource;
}
