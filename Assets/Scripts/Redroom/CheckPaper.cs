﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPaper : MonoBehaviour
{
    [SerializeField] GameObject mechine;
    // Start is called before the first frame update
    void Start()
    {
        mechine = GameObject.Find("mechine");
    }

    // Update is called once per frame
    void Update()
    {
        if (!mechine.GetComponent<Mechine>().paperin)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
