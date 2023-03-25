using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{

    [SerializeField]
    private AudioSource sfxSource;   // Audio source for sound effects
    [SerializeField]
    private AudioSource musicSource; // Audio source for music

    // Singleton instance
    private static AudioManager instance = null;

    // Get the singleton instance
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "AudioManager";
                    instance = go.AddComponent<AudioManager>();
                }
            }
            return instance;
        }
    }

    // Play a sound effect
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }

    // Play a music track
    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    // Stop playing music
    public void StopMusic()
    {
        musicSource.Stop();
    }

    // Set the volume for sound effects
    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    // Set the volume for music
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
}
