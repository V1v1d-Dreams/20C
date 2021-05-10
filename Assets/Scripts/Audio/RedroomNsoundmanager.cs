using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RedroomNsoundmanager : MonoBehaviour
{
    [SerializeField] AudioSource aud;

    [SerializeField] AudioClip en12;
    [SerializeField] AudioClip en3;
    [SerializeField] AudioClip select;
    [SerializeField] AudioClip cash;
    [SerializeField] AudioClip bin;

    public void Scroll12()
    {
        if (!aud.isPlaying)
        {
            aud.pitch = Random.Range(0.8f, 1.2f);
            aud.PlayOneShot(en12);
        }
        
        //do something with example sound
    }

    public void Scroll3()
    {
        aud.pitch = Random.Range(0.8f, 1.2f);
        aud.PlayOneShot(en3);
        //do something with this
    }

    public void Picselect()
    {
        aud.pitch = Random.Range(0.8f, 1.2f);
        aud.PlayOneShot(select);
        //do something with this
    }

    public void Cashearn()
    {
        aud.pitch = 1f;
        aud.PlayOneShot(cash);
        //do something with this
    }

    public void Bin()
    {
        aud.pitch = Random.Range(0.8f, 1.2f);
        aud.PlayOneShot(bin);
        //do something with this
    }
}
