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
                Loaded = true;
                print("Assign 1");
                break;
            case 2://
                Datdaysong[0] = allsong[1];
                Datdaysong[1] = allsong[2];
                Datdaysong[2] = allsong[3];
                Loaded = true;
                print("Assign 2");
                break;
            case 3://
                Datdaysong[0] = allsong[5];
                Datdaysong[1] = allsong[3];
                Datdaysong[2] = allsong[4];
                Loaded = true;
                print("Assign 3");
                break;
            case 4://
                Datdaysong[0] = allsong[7];
                Datdaysong[1] = allsong[5];
                Datdaysong[2] = allsong[6];
                Loaded = true;
                print("Assign 4");
                break;
            case 5://
                Datdaysong[0] = allsong[8];
                Datdaysong[1] = allsong[6];
                Datdaysong[2] = allsong[7];
                Loaded = true;
                print("Assign 5");
                break;
            case 6://
                Datdaysong[0] = allsong[6];
                Datdaysong[1] = allsong[7];
                Datdaysong[2] = allsong[8];
                Loaded = true;
                print("Assign 6");
                break;
            case 7://
                Datdaysong[0] = allsong[0];
                Datdaysong[1] = allsong[8];
                Datdaysong[2] = allsong[9];
                Loaded = true;
                print("Assign 6");
                break;
            case 8://
                Datdaysong[0] = allsong[11];
                Datdaysong[1] = allsong[1];
                Datdaysong[2] = allsong[10];
                Loaded = true;
                print("Assign 6");
                break;
            case 9://
                Datdaysong[0] = allsong[12];
                Datdaysong[1] = allsong[13];
                Datdaysong[2] = allsong[11];
                Loaded = true;
                print("Assign 6");
                break;
            case 10://
                Datdaysong[0] = allsong[14];
                Datdaysong[1] = allsong[15];
                Datdaysong[2] = allsong[16];
                Loaded = true;
                print("Assign 6");
                break;
            case 11://
                Datdaysong[0] = allsong[16];
                Datdaysong[1] = allsong[11];
                Datdaysong[2] = allsong[9];
                Loaded = true;
                print("Assign 6");
                break;
            default:
                Datdaysong[0] = allsong[0];
                Datdaysong[1] = allsong[1];
                Datdaysong[2] = allsong[2];
                Loaded = true;
                print("Defult song list");
                break;

        }
    }
}
