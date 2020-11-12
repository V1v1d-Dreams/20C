﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmoLpic : MonoBehaviour
{
    [SerializeField] public Sprite[] Smol;
    [SerializeField] public GameObject[] pic;
    int index = 0;
    [SerializeField] Transform spawnpt;
    [SerializeField] GameObject buttonL;
    [SerializeField] GameObject buttonR;
    [SerializeField] GameObject Overlay;
    [SerializeField] GameObject camleft;
    [SerializeField] GameObject camright;
    [SerializeField] public float timer = 2;
    [SerializeField] public float nextclicktime = 0;
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = Smol[0];
    }

    public void goleft()
    {
        if ((index -1) < 0)
        {
            index = Smol.Length - 1;
        }
        else
        {
            index -= 1;
        }
        this.GetComponent<SpriteRenderer>().sprite = Smol[index];
    }

    public void goright()
    {
        if ((index + 1) >= Smol.Length)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }
        this.GetComponent<SpriteRenderer>().sprite = Smol[index];
    }

    void OnMouseUp()
    {
        if (Time.time > nextclicktime)
        {
            print("instantiate");
            Instantiate(pic[index], spawnpt);
            buttonL.SetActive(false);
            buttonR.SetActive(false);
            Overlay.SetActive(false);
            gameObject.SetActive(false);
            camleft.SetActive(true);
            camright.SetActive(true);
            GameObject.Find("mechine").GetComponent<Mechine>().Opened = false;
            //GameObject.Find("mechine").GetComponent<Mechine>().paperin = false;
            //GameObject.Find("mechine").GetComponent<Mechine>().filmin = false;
            nextclicktime = Time.time + timer;
        }

    }
}
