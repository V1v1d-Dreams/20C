using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Dailyplaylist : MonoBehaviour
{
    public AudioClip[] allsong;
    public AudioClip[] Datdaysong;
    [System.NonSerialized] public bool Loaded = false;
    private static Dailyplaylist playerInstance;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            GameObject.Destroy(this);
        }
    }

    void Start()
    {
        //DontDestroyOnLoad(this);
        //Loaded = false;
        //StartCoroutine(Latestarts(0.30f));
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    IEnumerator Latestarts(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        LoadSong();
    }

    public void statCoroteen()
    {
        StartCoroutine(Latestarts(0.30f));
    }

    void LoadSong()
    {
        Datdaysong[0] = allsong[0];
        Datdaysong[1] = allsong[1];
        Datdaysong[2] = allsong[2];
        Datdaysong[3] = allsong[3];
        Datdaysong[4] = allsong[4];
        Datdaysong[5] = allsong[5];
        Datdaysong[6] = allsong[6];
        Datdaysong[7] = allsong[7];
        Datdaysong[8] = allsong[8];
        Datdaysong[9] = allsong[9];
        Datdaysong[10] = allsong[10];
        Datdaysong[11] = allsong[11];
        Datdaysong[12] = allsong[12];
        Datdaysong[13] = allsong[13];
        Datdaysong[14] = allsong[14];
        Datdaysong[15] = allsong[15];
        Datdaysong[16] = allsong[16];
        Loaded = true;

    }
}
