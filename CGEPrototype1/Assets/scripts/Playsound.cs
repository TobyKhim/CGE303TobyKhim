using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//require the audiosource to be attached
//to the gameover this script is attached to
[RequireComponent(typeof(AudioSource))]
public class PlaySound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip soundToPlay;
    public float volume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.PlayOneShot(soundToPlay, volume);
    }

    
}
