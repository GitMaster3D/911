using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource soundSource;
    public AudioSource musicSource;
    public AudioClip[] music;
    public static SoundManager instance;


    public void Awake()
    {
        instance = this;
    }

    public void PlaySound(AudioClip sound)
    {
        soundSource.PlayOneShot(sound);
    }

    public void PlaySounds(AudioClip[] sounds)
    {
        foreach (var sound in sounds) 
            PlaySound(sound);
    }

    public void PlayMusic(AudioClip song)
    {
        musicSource.PlayOneShot(song);
    }




    private void Update()
    {
        if (!musicSource.isPlaying && music.Length > 0)
            PlayMusic(music[Random.Range(0, music.Length)]);
        
    }
}
