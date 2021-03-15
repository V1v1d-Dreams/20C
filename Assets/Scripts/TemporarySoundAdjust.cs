using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TemporarySoundAdjust : MonoBehaviour
{
    public AudioMixer BGM;
    public AudioMixer SFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetvolBGM(float volume)
    {
        BGM.SetFloat("BGM", volume);
    }
    public void SetvolSFX(float volume)
    {
        SFX.SetFloat("SFX", volume);
    }
}
