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
        DontDestroyOnLoad(this);
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

        switch (staticDataHolder.daynumber)
        {
            case 1://
                Datdaysong[0] = allsong[0];
                Datdaysong[1] = allsong[1];
                Datdaysong[2] = allsong[2];
                Datdaysong[3] = allsong[3];
                Datdaysong[4] = allsong[4];
                Datdaysong[5] = allsong[5];
                Loaded = true;
                print("Assign 1");
                break;
            case 2://
                Datdaysong[0] = allsong[0];
                Datdaysong[1] = allsong[1];
                Datdaysong[2] = allsong[2];
                Datdaysong[3] = allsong[3];
                Datdaysong[4] = allsong[4];
                Datdaysong[5] = allsong[5];
                Loaded = true;
                print("Assign 2");
                break;
            case 3://
                Datdaysong[0] = allsong[6];
                Datdaysong[1] = allsong[1];
                Datdaysong[2] = allsong[2];
                Datdaysong[3] = allsong[3];
                Datdaysong[4] = allsong[4];
                Datdaysong[5] = allsong[5];
                Loaded = true;
                print("Assign 3");
                break;
            case 4://
                Datdaysong[0] = allsong[6];
                Datdaysong[1] = allsong[7];
                Datdaysong[2] = allsong[2];
                Datdaysong[3] = allsong[3];
                Datdaysong[4] = allsong[4];
                Datdaysong[5] = allsong[5];
                Loaded = true;
                print("Assign 4");
                break;
            case 5://
                Datdaysong[0] = allsong[6];
                Datdaysong[1] = allsong[7];
                Datdaysong[2] = allsong[8];
                Datdaysong[3] = allsong[3];
                Datdaysong[4] = allsong[4];
                Datdaysong[5] = allsong[5];
                Loaded = true;
                print("Assign 5");
                break;
            case 6://
                Datdaysong[0] = allsong[6];
                Datdaysong[1] = allsong[7];
                Datdaysong[2] = allsong[8];
                Datdaysong[3] = allsong[9];
                Datdaysong[4] = allsong[10];
                Datdaysong[5] = allsong[1];
                Loaded = true;
                print("Assign 6");
                break;
             default:
                Datdaysong[0] = allsong[6];
                Datdaysong[1] = allsong[7];
                Datdaysong[2] = allsong[8];
                Datdaysong[3] = allsong[9];
                Datdaysong[4] = allsong[10];
                Datdaysong[5] = allsong[1];
                Loaded = true;
                print("Defult song list");
                break;

        }
    }
}
