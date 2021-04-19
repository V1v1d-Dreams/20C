using System.Collections;
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
    [SerializeField] public bool Satisfied;
    [TextArea(2, 3)]
    [SerializeField] string[] DialogUnsat;
    [SerializeField] string[] NameUnsat;
    [SerializeField] Sprite[] characterUnsat;
    [SerializeField] GameObject shopOverlay;
    [SerializeField] Sprite News;
    [SerializeField] bool endday = false;
    [SerializeField] public int เหมาจ่าย;
    char[] Chararray;
    [Header("System Data")]
    float speed;
    [SerializeField] Transform Textstart;
    [SerializeField] Transform textlocation;
    [SerializeField] Transform Namestart;
    [SerializeField] Transform Namelocation;
    [SerializeField] GameObject Char;
    [SerializeField] GameObject Name;
    [SerializeField] int i = 0;
    [SerializeField] GameObject[] CharsObj;
    [SerializeField] char compare1;
    [SerializeField] float nextline;
    [SerializeField] GameObject textmanager;
    [SerializeField] GameObject Pic;
    //bool Stated = false;
    [SerializeField] int Timeindex;
    [SerializeField] int WhatDayisToday;
    [SerializeField] GameObject Film;
    [SerializeField] GameObject Film2;
    [SerializeField] GameObject Film3;
    [SerializeField] SpriteRenderer NewsOverlay;
    bool news = false;
    bool wave = false;
    bool chrome = false;
    bool red = false;
    bool finish = true;

    RaycastHit2D[] Click;
    Camera cam;

    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        textmanager = GameObject.Find("Textmanager");
        speed = textmanager.GetComponent<Textmanager>().TypeWriterSpeed;
        Pic = GameObject.Find("character");

        if (Satisfied)
        {
            Pic.GetComponent<SpriteRenderer>().sprite = character[i];
        }
        else
        {
            Pic.GetComponent<SpriteRenderer>().sprite = characterUnsat[i];
        }

        staticDataHolder.daynumber = WhatDayisToday;
        textlocation.position = new Vector3(Textstart.position.x, Textstart.position.y, textlocation.position.z);
        Namelocation.position = new Vector3(Namestart.position.x, Namestart.position.y, Namestart.position.z);
        
        if (News == null)
        {
            StartCoroutine(Typewritter(speed));
        }
        else
        {
            //Debug.Log("foundNews");
            NewsOverlay.enabled = true;
            news = true;
            NewsOverlay.sprite = News;
        }
    }

    void Update()
    {
        if (wave)
        {
            textmanager.GetComponent<Textmanager>().effect = Textmanager.Effects.Wave;
        }
        else if(chrome)
        {
            textmanager.GetComponent<Textmanager>().effect = Textmanager.Effects.chromatic;
        }
        else if (red)
        {
            textmanager.GetComponent<Textmanager>().effect = Textmanager.Effects.red;
        }
        else
        {
            textmanager.GetComponent<Textmanager>().effect = Textmanager.Effects.None;
        }

        if (Input.GetMouseButtonUp(0) && !PauseScript.GameIsPause)
        {
            if (news)
            {
                StartCoroutine(Typewritter(speed));
                NewsOverlay.enabled = false;
                news = false;
            }

            Click = Physics2D.RaycastAll(cam.ScreenToWorldPoint(Input.mousePosition), transform.forward);

            if (!Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition),transform.forward))
            {
                
            }
            else if (Click[0].collider.gameObject.CompareTag("TextBox"))
            {
                //DialogS();
                if (finish)
                {
                    StartCoroutine(Typewritter(speed));
                }
            }
        }
        else if(Input.GetKeyUp(KeyCode.Space) && !PauseScript.GameIsPause)
        {
            if (finish)
            {
                StartCoroutine(Typewritter(speed));
            }
        }
        else if(Input.GetKeyUp(KeyCode.F10) && !PauseScript.GameIsPause)
        {
            staticDataHolder.Todaysfilm = Film;
            staticDataHolder.Todaysfilm2 = Film2;
            staticDataHolder.Todaysfilm3 = Film3;
            GameObject.Find("GameProgressManager").GetComponent<Progressmanager>().End(endday);
        }
        else if (Input.GetKeyUp(KeyCode.F11) && !PauseScript.GameIsPause)
        {
            staticDataHolder.money += 100;
        }
    }

    IEnumerator Typewritter(float TypewriterSpeed)
    {
        WaitForSeconds wait = new WaitForSeconds(TypewriterSpeed);
        textlocation.position = new Vector3(Textstart.position.x, Textstart.position.y, textlocation.position.z);
        Namelocation.position = new Vector3(Namestart.position.x, Namestart.position.y, Namestart.position.z);
        if (Satisfied)
        {
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
                finish = false;
                for (int iNdex = 0; iNdex < Chararray.Length; iNdex++)
                {
                    if (Chararray[iNdex] == compare1 && Chararray[iNdex + 1] == 'n')
                    {
                        textlocation.position = new Vector3(Textstart.position.x, textlocation.position.y - nextline, textlocation.position.z);
                        iNdex += 1;
                        yield return wait;
                    }
                    else if (Chararray[iNdex] == compare1 && Chararray[iNdex + 1] == 'w')
                    {
                        wave = !wave;
                        iNdex += 1;
                        yield return wait;
                    }
                    else if (Chararray[iNdex] == compare1 && Chararray[iNdex + 1] == 'c')
                    {
                        chrome = !chrome;
                        iNdex += 1;
                        yield return wait;
                    }
                    else if (Chararray[iNdex] == compare1 && Chararray[iNdex + 1] == 'r')
                    {
                        red = !red;
                        iNdex += 1;
                        yield return wait;
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
                        yield return wait;
                    }
                }
                i++;
                finish = true;

            }
            else
            {
                if (ShopAfterThis)
                {
                    staticDataHolder.Todaysfilm = Film;
                    staticDataHolder.Todaysfilm2 = Film2;
                    staticDataHolder.Todaysfilm3 = Film3;
                    shopOverlay.SetActive(true);
                }
                else
                {
                    staticDataHolder.Todaysfilm = Film;
                    staticDataHolder.Todaysfilm2 = Film2;
                    staticDataHolder.Todaysfilm3 = Film3;
                    GameObject.Find("GameProgressManager").GetComponent<Progressmanager>().End(endday);
                }
            }
        }
        else
        {
            if (i < DialogUnsat.Length)
            {

                textmanager.GetComponent<Textmanager>().NewtextPos = 0;

                //find all letter and for loop delete
                CharsObj = GameObject.FindGameObjectsWithTag("letter");
                for (int A = 0; A < CharsObj.Length; A++)
                {
                    Destroy(CharsObj[A]);
                }

                //---------------------------Name--------------------------
                Chararray = NameUnsat[i].ToCharArray();
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
                Pic.GetComponent<SpriteRenderer>().sprite = characterUnsat[i];
                //---------------------------Sprite------------------------

                Chararray = DialogUnsat[i].ToCharArray();
                finish = false;
                for (int iNdex = 0; iNdex < Chararray.Length; iNdex++)
                {
                    if (Chararray[iNdex] == compare1 && Chararray[iNdex + 1] == 'n')
                    {
                        textlocation.position = new Vector3(Textstart.position.x, textlocation.position.y - nextline, textlocation.position.z);
                        iNdex += 1;
                        yield return wait;
                    }
                    else if (Chararray[iNdex] == compare1 && Chararray[iNdex + 1] == 'w')
                    {
                        wave = !wave;
                        iNdex += 1;
                        yield return wait;
                    }
                    else if (Chararray[iNdex] == compare1 && Chararray[iNdex + 1] == 'c')
                    {
                        chrome = !chrome;
                        iNdex += 1;
                        yield return wait;
                    }
                    else if (Chararray[iNdex] == compare1 && Chararray[iNdex + 1] == 'r')
                    {
                        red = !red;
                        iNdex += 1;
                        yield return wait;
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
                        yield return wait;
                    }
                }
                i++;
                finish = true;
            }
            else
            {
                if (ShopAfterThis)
                {
                    staticDataHolder.Todaysfilm = Film;
                    staticDataHolder.Todaysfilm2 = Film2;
                    staticDataHolder.Todaysfilm3 = Film3;
                    เหมาจ่าย = staticDataHolder.lumpsum;

                    //pause & play on this

                    shopOverlay.SetActive(true);
                }
                else
                {
                    staticDataHolder.Todaysfilm = Film;
                    staticDataHolder.Todaysfilm2 = Film2;
                    staticDataHolder.Todaysfilm3 = Film3;
                    เหมาจ่าย = staticDataHolder.lumpsum;

                    //pause & play on this

                    GameObject.Find("GameProgressManager").GetComponent<Progressmanager>().End(endday);
                }
            }
        }
    }
}
