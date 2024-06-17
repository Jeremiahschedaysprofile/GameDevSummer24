using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance // a static variable other scripts can use to find this script
    {
        get;
        private set;
    }

    public Sound[] sounds; // this is list of the sound object

    private void Awake ()
    {
        if (Instance != null) // if there is already another AudioManager in the scene 
        {
            // Destroy this extra copy
            Destroy(this.gameObject);
        }
        else // there is no other AudioManager in the scene
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject); // do not destroy AudioManager

        foreach (Sound s in sounds) // for each sound object in this manager sound list
        {
            s.audioSource = gameObject.AddComponent<AudioSource>(); // attach an audio source componet to that object

            //Inittialize the values for this sound 
            s.audioSource.clip = s.audioClip;
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.loop;
        }

    }

    private void Start()
    {
        // play maintheme music
        PlaySound("MainTheme");
    }

     public void PlaySound(string name)
        {
            Sound sound = Array.Find(sounds, sound => sound.name == name); // find the sound script

            if (sound == null) // if the sound we are looking does not exist...
            {
                Debug.LogWarning("Could not find" + name + " sound!");
                return; // exit out of this function becasue the sound was found
            }

            sound.audioSource.Play();
        }

        public void StopSound(string name)
        {
            Sound sound = Array.Find(sounds, sound => sound.name == name); // find the sound script

            if (sound == null) // if the sound we are looking does not exist...
            {
                Debug.LogWarning("Could not find" + name + " sound!");
                return; // exit out of this function becasue the sound was found
            }

            sound.audioSource.Stop();
        }

}
