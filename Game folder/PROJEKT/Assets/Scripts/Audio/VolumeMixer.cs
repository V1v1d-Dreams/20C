﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//public class VolumeMixer : MonoBehaviour
//{
//public AudioMixer audioMixer;
//public void SetVolume(float volume)
//{
//audioMixer.SetFloat("volume", volume);    
//take 0.0001 to 1 volume turn it into -80, -0 in algorithm scale
//audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
//}
//}

public class VolumeMixer : MonoBehaviour
{
    public static VolumeMixer soundForce;
    public AudioMixer audioMixer;
    public Slider slider;
    public string Exposer;
    [Header("Sound check")]
    [Tooltip("For when pressing the button, the sound will play out")]
    public bool soundCheck;
    public AudioSource audioSource;
    public AudioClip onSoundTest;

    void Awake()
    {
        soundForce = this;
    }

    void Start()
    {
        //soundEffectTester.SetActive(false);
        //slider.value = PlayerPrefs.GetFloat(Exposer, 1.00f);
        //**********************************************************

        //print(audioMixer.name + slider.value);
        slider.value = PlayerPrefs.GetFloat(Exposer);
        SetVolume(slider.value);
        //print(audioMixer.name + slider.value);
    }
    public void SetVolume (float sliderValue)
    {  
        audioMixer.SetFloat(Exposer, Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat(Exposer, sliderValue);
    }
    public void PlayEffectOnce()
    {
        if (soundCheck == true)
        {
            audioSource.PlayOneShot(onSoundTest);
        }
    }
}

