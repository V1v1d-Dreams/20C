using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MP3Player : MonoBehaviour
{
    public Dropdown songlistdrop;

    public AudioClip[] clips;
    public List<string> songname;
    int curtrack;
    int prevtrack = -1;
    private float timer;
    private float stopti = 0;
    private float newclip;
    public AudioSource source;

    int songcap;
    bool pausing = true;
    bool nextsong;
    int clipNum;
    int i = 0;
    int prevday = 0;
    int songindex;
    // Start is called before the first frame update
    void Start()
    {
        clips = new AudioClip[3];
        source = GetComponent<AudioSource>();
        //StartCoroutine(Latestart(0.35f));
    }
    public void listconvert()
    {
        songname.Clear();
        songlistdrop.value = 0;

        for (i = 0; i < clips.Length; i++)
        {
           // print("im running");
            songname.Add(clips[i].name);
            
        }
       
        populate();
    }
    void populate()
    {
        print("Songcount" + songlistdrop.options.Count);
        for (i = songlistdrop.options.Count-1; i >= 0; i--)
        {
            songlistdrop.options.RemoveAt(i);
            print(i);
        }

        songlistdrop.AddOptions(songname);
        next();
    }
    public void Dropdown_IndexChanged(int Index = 0)
    {
        songindex = Index;
        source.Stop();
        songchange();

    }

    void songchange()
    {
       // print("index = " + songindex);
        nextsong = false;
        source.PlayOneShot(clips[songindex]);
        newclip = clips[songindex].length;
        curtrack = songindex;
    }
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            for (i = 0; i < songname.Count; i++)
            {
                print(songname[i]);
            }
        }

        if (GetComponent<Dailyplaylist>().Loaded)
        {
            if (staticDataHolder.daynumber != prevday)
            {
                clips = new AudioClip[3];
                source = GetComponent<AudioSource>();
                prevday = staticDataHolder.daynumber;

                for (i = 0; i < 3; i++)
                {
                    clips[i] = GetComponent<Dailyplaylist>().Datdaysong[i];
                }
                listconvert();
            }
            timer += Time.deltaTime;

            if (timer >= newclip + 1)
            {
                prevtrack = curtrack;
                newsong();
                timer = 0;
            }
        }

    }
    void newsong()
    {
        clipNum = Random.Range(0, clips.Length);
        if (clipNum != prevtrack)
        {
            if (!source.isPlaying)
            {
                nextsong = false;
                source.loop = true;
                source.PlayOneShot(clips[clipNum]);
                curtrack = clipNum;
                songlistdrop.value = clipNum;
            }

            newclip = clips[clipNum].length;
        }
        else
        {
            newsong();
        }
        //print("curtrack =" + curtrack);
        //print("prevtrack =" + prevtrack);
        //print("--------------");
        
    }

    void prevsong()
    {
        nextsong = false;
        source.PlayOneShot(clips[prevtrack]);
        newclip = clips[prevtrack].length;
        curtrack = prevtrack;
        songlistdrop.value = prevtrack;
    }

    void pauseandplay()
    {
        if (pausing)
        {
            //print("timer = " + timer);
            source.Pause();
            stopti = timer;
            pausing = false;
            
        }
        else if (!pausing)
        {
            source.UnPause();
            timer = stopti;     
            pausing = true;
           // print("stoptimer = " + stopti);
        }
    }


    public void play()
    {
        pauseandplay();
    }

    public void next()
    {
        source.Stop();
        prevtrack = curtrack;
        nextsong = true;
        newsong();
        timer = 0;
    }

    public void prev()
    {
        if(prevtrack < 0)
        {
            prevtrack = clipNum;
            source.Stop();
            prevsong();
            timer = 0;
        }
        else
        {
            source.Stop();
            prevsong();
            timer = 0;
        }
        
    }

    IEnumerator Latestart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

    }
}

