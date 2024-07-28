using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource soundEffectSource;
    public AudioSource backgroundMusicSource;

    public static AudioManager Instance = null; // Singleton 


    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this) //ensure instance is Singleton
        {
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);
    }

    // Play a single clip through the sound effects source.
    public void Play(AudioClip clip)
    {
        soundEffectSource.clip = clip;
        soundEffectSource.Play();
    }

    // Play a single clip through the music source.
    public void PlayMusic(AudioClip clip)
    {
        backgroundMusicSource.clip = clip;
        backgroundMusicSource.Play();
    }
}
