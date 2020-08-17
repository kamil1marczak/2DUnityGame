using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautSounds : MonoBehaviour
{
    public AudioClip[] sounds;
    AudioSource _hurtSound;
    AudioSource _endGameSound;
    void Start()
    {
        _hurtSound = AddAudio (false, true);
        _endGameSound = AddAudio (false, false);
    }
    public AudioSource AddAudio(bool loop, bool playAwake) 
    { 
        AudioSource newAudio = gameObject.AddComponent<AudioSource>();
        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        return newAudio; 
    }
    public void PlayHurtSounds()
    {
        _hurtSound.clip = sounds[0];
        _hurtSound.Play ();
    }

    public void PlayEndGameSound()
    {
        _endGameSound.clip = sounds[1];
        _endGameSound.Play();
    }
    
}
