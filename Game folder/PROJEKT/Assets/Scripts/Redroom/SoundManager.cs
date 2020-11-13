using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [Tooltip("Input Fx here, 0 is waternoise 1 is film In enlarger 2 paper noise 3 clip noise")]
    [SerializeField] public AudioClip[] FX;
    [System.NonSerialized] AudioSource Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayFX(int Var)
    {
        Player.pitch = Random.Range(0.8f, 1.2f);
        Player.PlayOneShot(FX[Var]);
    }
    
}
