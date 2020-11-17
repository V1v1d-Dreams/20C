using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Dailyplaylist : MonoBehaviour
{
    public AudioClip[] allsong;
    public AudioClip[] Datdaysong;
    // Start is called before the first frame update
    void Start()
    {
        switch(staticDataHolder.daynumber)
        {
            default://
                Datdaysong[0] = allsong[0];
                Datdaysong[1] = allsong[1];
                Datdaysong[2] = allsong[2];
                Datdaysong[3] = allsong[3];
                Datdaysong[4] = allsong[4];
                Datdaysong[5] = allsong[5];
                break;
            case 2://
                Datdaysong[0] = allsong[6];
                Datdaysong[1] = allsong[7];
                Datdaysong[2] = allsong[8];
                Datdaysong[3] = allsong[9];
                Datdaysong[4] = allsong[10];
                Datdaysong[5] = allsong[5];
                break;
            case 3://
                Datdaysong[0] = allsong[0];
                Datdaysong[1] = allsong[1];
                Datdaysong[2] = allsong[2];
                Datdaysong[3] = allsong[3];
                Datdaysong[4] = allsong[4];
                Datdaysong[5] = allsong[5];
                break;
            case 4://
                Datdaysong[0] = allsong[0];
                Datdaysong[1] = allsong[1];
                Datdaysong[2] = allsong[2];
                Datdaysong[3] = allsong[3];
                Datdaysong[4] = allsong[4];
                Datdaysong[5] = allsong[5];
                break;
            case 5://
                Datdaysong[0] = allsong[0];
                Datdaysong[1] = allsong[1];
                Datdaysong[2] = allsong[2];
                Datdaysong[3] = allsong[3];
                Datdaysong[4] = allsong[4];
                Datdaysong[5] = allsong[5];
                break;
            case 6://
                Datdaysong[0] = allsong[0];
                Datdaysong[1] = allsong[1];
                Datdaysong[2] = allsong[2];
                Datdaysong[3] = allsong[3];
                Datdaysong[4] = allsong[4];
                Datdaysong[5] = allsong[5];
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
}
