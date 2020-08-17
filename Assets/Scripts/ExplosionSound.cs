using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSound : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip[] explosionSounds;

    public void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        int randSound = Random.Range(0, explosionSounds.Length);
        _audioSource.clip = explosionSounds[randSound];
        _audioSource.Play();
    }
}
