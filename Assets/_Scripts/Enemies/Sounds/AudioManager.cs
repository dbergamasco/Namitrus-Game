using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("TestMusic2");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x=> x.name == name);
        if (s == null)
        {
            Debug.Log("Music not found!");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }

    }

    public void PlaySfx(string name)
    {
        Sound s = Array.Find(sfxSounds, x=> x.name == name);
        if (s == null)
        {
            Debug.Log("SFX not found!");
        }
        else
        {
            sfxSource.clip = s.clip;
            sfxSource.Play();
        }

    }
}

