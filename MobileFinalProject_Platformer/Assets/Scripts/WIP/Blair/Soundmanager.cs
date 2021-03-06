﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Soundmanager : MonoBehaviour
{

    public static Soundmanager instance = null;
    public AudioClip PlayerDamaged, Jump, SwipeMove, PowerUp, Slowed, Click, Blip;
    public AudioSource AudSrc, MusicSrc;
    public float SfxGlobalModifier, MusicGlobalModifier, StartingMusicVolume;
    public GameObject SfxSlider, MusicSlider;
    public bool InvertedControls;
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {

        SfxGlobalModifier = 1; MusicGlobalModifier = 1;
        MusicSrc.volume = StartingMusicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenuScene")
        {
            MusicSrc.mute = true;
        }
        else
        {
            MusicSrc.mute = false;
        }
    }

    public void PlaySoundOneShot(AudioClip snd, float volume)
    {
        AudSrc.volume = volume * SfxGlobalModifier;
        AudSrc.PlayOneShot(snd);
    }
    
    public void ChangeSoundVolume()
    {
        SfxGlobalModifier = SfxSlider.GetComponent<Slider>().value;
    }

    public void ChangeMusicVolume()
    {
        MusicGlobalModifier = MusicSlider.GetComponent<Slider>().value;
        MusicSrc.volume = StartingMusicVolume * MusicGlobalModifier;
    }
}
