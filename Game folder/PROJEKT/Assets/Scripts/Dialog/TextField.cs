﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextField : MonoBehaviour
{
    [Header("Input Data Here")]
    [TextArea(2, 3)]
    [SerializeField] string[] Dialog;
    [SerializeField] string[] Names;
    [SerializeField] Sprite[] character;
    [SerializeField] bool ShopAfterThis = false;
    [SerializeField] GameObject shopOverlay;
    char[] Chararray;
    [Header("System Data")]
    [SerializeField] Transform Textstart;
    [SerializeField] Transform textlocation;
    [SerializeField] Transform Namestart;
    [SerializeField] Transform Namelocation;
    [SerializeField] GameObject Char;
    [SerializeField] GameObject Name;
    [SerializeField] int i = 0;
    [SerializeField] GameObject[] CharsObj;
    [SerializeField] char compare1;
    [SerializeField] char compare2;
    [SerializeField] float nextline;
    [SerializeField] GameObject textmanager;
    [SerializeField] GameObject Pic;
    bool Stated = false;
    [SerializeField] int Timeindex;
    [SerializeField] int WhatDayisToday;
    [SerializeField] GameObject Film;

    RaycastHit2D[] Click;
    Camera cam;

    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        textmanager = GameObject.Find("Textmanager");
        Pic = GameObject.Find("character");
        Pic.GetComponent<SpriteRenderer>().sprite = character[i];
    }

    void Update()
    {
        if (Stated == false)
        {
            staticDataHolder.daynumber = WhatDayisToday;
            textlocation.position = new Vector3(Textstart.position.x, Textstart.position.y, textlocation.position.z);
            Namelocation.position = new Vector3(Namestart.position.x, Namestart.position.y, Namestart.position.z);
            if (i < Dialog.Length)
            {

                textmanager.GetComponent<Textmanager>().NewtextPos = 0;

                //find all letter and for loop delete
                CharsObj = GameObject.FindGameObjectsWithTag("letter");
                for (int A = 0; A < CharsObj.Length; A++)
                {
                    Destroy(CharsObj[A]);
                }

                //---------------------------Name--------------------------
                Chararray = Names[i].ToCharArray();
                for (int iNdex = 0; iNdex < Chararray.Length; iNdex++)
                {
                    if (iNdex + 1 < Chararray.Length)
                    {
                        Namelocation.position = new Vector3(textmanager.GetComponent<Textmanager>().DisplayName(Chararray[iNdex], Namelocation, Name, Chararray[iNdex + 1]), Namelocation.position.y, Namelocation.position.z);
                    }
                    else
                    {
                        Namelocation.position = new Vector3(textmanager.GetComponent<Textmanager>().DisplayName(Chararray[iNdex], Namelocation, Name), Namelocation.position.y, Namelocation.position.z);
                    }
                }
                //---------------------------Name--------------------------

                Chararray = Dialog[i].ToCharArray();
                for (int iNdex = 0; iNdex < Chararray.Length; iNdex++)
                {
                    if (Chararray[iNdex] == compare1 && Chararray[iNdex + 1] == compare2)
                    {
                        textlocation.position = new Vector3(Textstart.position.x, textlocation.position.y - nextline, textlocation.position.z);
                        iNdex += 1;
                    }
                    else
                    {
                        if (iNdex + 1 < Chararray.Length)
                        {
                            textlocation.position = new Vector3(textmanager.GetComponent<Textmanager>().DisplayDialog(Chararray[iNdex], textlocation, Char, Chararray[iNdex + 1]), textlocation.position.y, textlocation.position.z);
                        }
                        else
                        {
                            textlocation.position = new Vector3(textmanager.GetComponent<Textmanager>().DisplayDialog(Chararray[iNdex], textlocation, Char), textlocation.position.y, textlocation.position.z);
                        }
                    }
                }
                i++;
            }
            else
            {
                GameObject.Find("levelLoader").GetComponent<Levelloader>().loadLV(3);
            }

            Stated = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Click = Physics2D.RaycastAll(cam.ScreenToWorldPoint(Input.mousePosition), transform.forward);

            if (!Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition),transform.forward))
            {
                
            }
            else if (Click[0].collider.gameObject.CompareTag("TextBox"))
            {
                DialogS();
            }
        }
        else if(Input.GetKeyUp(KeyCode.Space) && !PauseScript.GameIsPause)
        {
            DialogS();
        }    
    }


    void DialogS()
    {
        textlocation.position = new Vector3(Textstart.position.x, Textstart.position.y, textlocation.position.z);
        Namelocation.position = new Vector3(Namestart.position.x, Namestart.position.y, Namestart.position.z);
        if (i < Dialog.Length)
        {

            textmanager.GetComponent<Textmanager>().NewtextPos = 0;

            //find all letter and for loop delete
            CharsObj = GameObject.FindGameObjectsWithTag("letter");
            for (int A = 0; A < CharsObj.Length; A++)
            {
                Destroy(CharsObj[A]);
            }

            //---------------------------Name--------------------------
            Chararray = Names[i].ToCharArray();
            for (int iNdex = 0; iNdex < Chararray.Length; iNdex++)
            {
                if (iNdex + 1 < Chararray.Length)
                {
                    Namelocation.position = new Vector3(textmanager.GetComponent<Textmanager>().DisplayName(Chararray[iNdex], Namelocation, Name, Chararray[iNdex + 1]), Namelocation.position.y, Namelocation.position.z);
                }
                else
                {
                    Namelocation.position = new Vector3(textmanager.GetComponent<Textmanager>().DisplayName(Chararray[iNdex], Namelocation, Name), Namelocation.position.y, Namelocation.position.z);
                }
            }
            //---------------------------Name--------------------------

            //---------------------------Sprite------------------------
            Pic.GetComponent<SpriteRenderer>().sprite = character[i];
            //---------------------------Sprite------------------------

            Chararray = Dialog[i].ToCharArray();
            for (int iNdex = 0; iNdex < Chararray.Length; iNdex++)
            {
                if (Chararray[iNdex] == compare1 && Chararray[iNdex + 1] == compare2)
                {
                    textlocation.position = new Vector3(Textstart.position.x, textlocation.position.y - nextline, textlocation.position.z);
                    iNdex += 1;
                }
                else
                {
                    if (iNdex + 1 < Chararray.Length)
                    {
                        textlocation.position = new Vector3(textmanager.GetComponent<Textmanager>().DisplayDialog(Chararray[iNdex], textlocation, Char, Chararray[iNdex + 1]), textlocation.position.y, textlocation.position.z);
                    }
                    else
                    {
                        textlocation.position = new Vector3(textmanager.GetComponent<Textmanager>().DisplayDialog(Chararray[iNdex], textlocation, Char), textlocation.position.y, textlocation.position.z);
                    }
                }
            }
            i++;
        }
        else
        {
            if (ShopAfterThis)
            {
                staticDataHolder.Todaysfilm = Film;
                shopOverlay.SetActive(true);
            }
            else
            {
                staticDataHolder.Todaysfilm = Film;
                GameObject.Find("GameProgressManager").GetComponent<Progressmanager>().End();
            }
        }
    }
}
