using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audio;
    public static AudioManager manager;

    void Start()
    {
        manager = this;
    }

    public void Play(AudioClip clip){
        audio.clip = clip;
        audio.Play();
    }
}
