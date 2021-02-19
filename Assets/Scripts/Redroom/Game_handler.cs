﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_handler : MonoBehaviour
{
    [SerializeField] public Camera cam;
    [SerializeField] GameObject film;
    [SerializeField] GameObject paper;
    [SerializeField] Transform filmpos;
    [SerializeField] Transform paperpos;
    [SerializeField] GameObject inv1;
    [SerializeField] GameObject inv2;
    [SerializeField] public bool placable = false;
    [SerializeField] Transform[] children;
    [SerializeField] public GameObject SoundManager;
    [SerializeField] public int Magnifier_Lv = 1;
    [SerializeField] public int Hanger_Lv = 1;
    [SerializeField] Transform[] countingArray;
    [SerializeField] List<Transform> Piclist;
    [SerializeField] GameObject ResultOverlay;
    [SerializeField] Text ResiltText;
    [SerializeField] GameObject Hanger1;
    [SerializeField] GameObject Hanger2;
    [SerializeField] GameObject Hanger3;

    [Header("MouseOnSomething")]
    [SerializeField] public GameObject currentmouseon;
    [SerializeField] public bool mouseonINV;
    [SerializeField] public bool mouseontoolINV;
    [SerializeField] public bool mouseonTray1;
    [SerializeField] public bool mouseonTray2;
    [SerializeField] public bool mouseonTray3;

    [Header("Timer")]
    [SerializeField] public float Times;
    [SerializeField] public float currenttime;
    [SerializeField] public Text textsss;

    //[Header("campos")]
    //[SerializeField] public int[] CamPosittion;
    //[SerializeField] public int CurrentCamPos = 1;

    [Header("Bool")]
    [SerializeField] public bool overlay = false;

    RaycastHit2D[] raycast;
    RaycastHit2D[] Click;
    void Start()
    {
        //cam_follow_pos = cam.transform.position;
        Magnifier_Lv = staticDataHolder.mechinelv;
        Hanger_Lv = staticDataHolder.hangerLv;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.O))
        {
            Magnifier_Lv += 1;
            staticDataHolder.mechinelv += 1;
        }

        if (!overlay)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Click = Physics2D.RaycastAll(cam.ScreenToWorldPoint(Input.mousePosition), transform.forward);

                if (!Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), transform.forward))
                {

                }
                else if (Click[0].collider.gameObject.CompareTag("Paper"))
                {
                    Click[0].collider.gameObject.GetComponent<Paper>().isholding = true;
                    print(Click[0].collider.gameObject.name);
                }
                else if (Click[0].collider.gameObject.CompareTag("Photo"))
                {
                    if (!Click[0].collider.gameObject.GetComponent<Picture>().locked)
                    {
                        Click[0].collider.gameObject.GetComponent<Picture>().isholding = true;
                    }
                    print(Click[0].collider.gameObject.name);
                }
                else if (Click[0].collider.gameObject.CompareTag("FilmItem"))
                {
                    Click[0].collider.gameObject.GetComponent<Film>().isholding = true;
                    print(Click[0].collider.gameObject.name);
                }
                else
                {
                    if (Click[1].collider.gameObject.CompareTag("Photo"))
                    {
                        if (!Click[0].collider.gameObject.GetComponent<Picture>().locked)
                        {
                            Click[1].collider.gameObject.GetComponent<Picture>().isholding = true;
                        }
                    }
                    print(Click[0].collider.gameObject.name);
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                raycast = Physics2D.RaycastAll(cam.ScreenToWorldPoint(Input.mousePosition), transform.forward);
                for (int i = raycast.Length - 1; i >= 0; i--)
                {
                    if (raycast[i].collider.gameObject.CompareTag("bin") && Click[0].collider.CompareTag("Photo"))
                    {
                        Destroy(Click[0].collider.gameObject);
                    }
                }

                if (!Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), transform.forward))
                {

                }
                else if (Click[0].collider.gameObject.CompareTag("Paper"))
                {
                    Click[0].collider.gameObject.GetComponent<Paper>().isholding = false;
                    Click[0].collider.gameObject.GetComponent<Paper>().transform.position = new Vector2(Click[0].collider.gameObject.GetComponent<Paper>().innitialpos.x, Click[0].collider.gameObject.GetComponent<Paper>().innitialpos.y);
                    SoundManager.GetComponent<SoundManager>().PlayFX(2);
                }
                else if (Click[0].collider.gameObject.CompareTag("FilmItem"))
                {
                    Click[0].collider.gameObject.GetComponent<Film>().isholding = false;
                    Click[0].collider.gameObject.GetComponent<Film>().transform.position = new Vector2(Click[0].collider.gameObject.GetComponent<Film>().innitialpos.x, Click[0].collider.gameObject.GetComponent<Film>().innitialpos.y);
                }
                
            }
        }

        raycasting();

    }
    /*
    void dynamicmovespeed()
    {
        float maxspeed = 10f;

        if ((Screen.width - Input.mousePosition.x) > (Screen.width / 2))
        {
            //if right
            if (Input.mousePosition.x < edgesize)
            {
                //if in edge area
                moveAmount = ((edgesize - Input.mousePosition.x) / edgesize) * maxspeed;
            }
            else
            {
                moveAmount = 0;
            }
        }
        else
        {
            //if left
            if (Input.mousePosition.x > (Screen.width - edgesize))
            {
                //if in edge area
                moveAmount = ((Input.mousePosition.x - (Screen.width - edgesize)) / edgesize) * maxspeed;
            }
            else
            {
                moveAmount = 0;
            }
        }
    }

    void movecam()
    {
        if (!GameObject.Find("mechine").GetComponent<Mechine>().Opened)
        {
            if (cam.transform.position.x > minpos_X.position.x)
            {
                if (Input.mousePosition.x < edgesize)
                {
                    cam_follow_pos.x -= moveAmount * Time.deltaTime;
                }

            }

            if (cam.transform.position.x < maxpos_X.position.x)
            {
                if (Input.mousePosition.x > Screen.width - edgesize)
                {
                    cam_follow_pos.x += moveAmount * Time.deltaTime;
                }
            }

            cam.transform.position = Vector3.Lerp(cam.transform.position, cam_follow_pos, 4f);
        }
    }

    public void respawn()
    {
        Instantiate(film,filmpos);
        Instantiate(paper, paperpos);
    }
    */
    void raycasting()
    {
        mouseonINV = false;
        mouseontoolINV = false;
        placable = false;
        mouseonTray1 = false;
        mouseonTray2 = false;
        mouseonTray3 = false;
        raycast = Physics2D.RaycastAll(cam.ScreenToWorldPoint(Input.mousePosition),transform.forward);
        for (int i = raycast.Length -1; i >= 0; i--)
        {
            if (raycast[i].collider.gameObject.CompareTag("Inventory"))
            {
                currentmouseon = raycast[i].collider.gameObject;
                mouseonINV = true;
                break;
            }
            else if (raycast[i].collider.gameObject.CompareTag("Hanger"))
            {
                currentmouseon = raycast[i].collider.gameObject;

                if (!raycast[i].collider.gameObject.GetComponent<Item_with_slot>().Locked)
                {
                    placable = true;
                    break;
                }
            }
            else if (raycast[i].collider.gameObject.CompareTag("tray1"))
            {
                currentmouseon = raycast[i].collider.gameObject;

                if (!raycast[i].collider.gameObject.GetComponent<Item_with_slot>().Locked)
                {
                    placable = true;
                }

                mouseonTray1 = true;
                break;
            }
            else if (raycast[i].collider.gameObject.CompareTag("tray2"))
            {
                currentmouseon = raycast[i].collider.gameObject;

                if (!raycast[i].collider.gameObject.GetComponent<Item_with_slot>().Locked)
                {
                    placable = true;
                }

                mouseonTray2 = true;
                break;
            }
            else if (raycast[i].collider.gameObject.CompareTag("tray3"))
            {
                currentmouseon = raycast[i].collider.gameObject;

                if (!raycast[i].collider.gameObject.GetComponent<Item_with_slot>().Locked)
                {
                    placable = true;
                }

                mouseonTray3 = true;
                break;
            }
            else if (raycast[i].collider.gameObject.CompareTag("paperhere"))
            {
                Click[0].collider.gameObject.GetComponent<Paper>().mouseOnPaper = true;
                if (Input.GetMouseButtonUp(0))
                {
                    GameObject.Find("mechine").GetComponent<Mechine>().paperin = true;
                }
                break;
            }
            else if (raycast[i].collider.gameObject.CompareTag("Film"))
            {
                Click[0].collider.gameObject.GetComponent<Film>().mouseOnfilm = true;
                if (Input.GetMouseButtonUp(0))
                {
                    //transform.position = new Vector2(innitialpos.x, innitialpos.y);
                    GameObject.Find("mechine").GetComponent<Mechine>().filmin = true;
                    //GameObject.Find("mechine").GetComponent<Mechine>().smolpic.GetComponent<SmoLpic>().pic = Click[0].collider.gameObject.GetComponent<Film>().picturearray;
                    //GameObject.Find("mechine").GetComponent<Mechine>().smolpic.GetComponent<SmoLpic>().Smol = Click[0].collider.gameObject.GetComponent<Film>().BlurArray;
                    SoundManager.GetComponent<SoundManager>().PlayFX(1);
                }
                break;
            }
            //Change to switch
        }
    }

    void timer()
    {
        textsss.text = currenttime + "/" + Times;
        if (currenttime < Times)
        {
            currenttime += Time.deltaTime;
        }
        else
        {
            GameObject.Find("levelLoader").GetComponent<Levelloader>().loadLV(2);
        }
    }

    /*
    public void moveleft()
    {
        if ((CurrentCamPos-1) < 0)
        {
            cam.transform.position = new Vector3(CamPosittion[CamPosittion.Length -1], cam.transform.position.y, cam.transform.position.z);
            CurrentCamPos = CamPosittion.Length - 1;
        }
        else
        {
            cam.transform.position = new Vector3(CamPosittion[CurrentCamPos - 1], cam.transform.position.y, cam.transform.position.z);
            CurrentCamPos -= 1;
        }

    }

    public void moveright()
    {
        if ((CurrentCamPos + 1) == CamPosittion.Length)
        {
            cam.transform.position = new Vector3(CamPosittion[0], cam.transform.position.y, cam.transform.position.z);
            CurrentCamPos = 0;

        }
        else
        {
            cam.transform.position = new Vector3(CamPosittion[CurrentCamPos + 1], cam.transform.position.y, cam.transform.position.z);
            CurrentCamPos += 1;
        }
    }
    */

    public void RedRoomexit()
    {
        GameObject.Find("exit_Button").SetActive(false);

        double result = 0;
        GameObject photoinv = GameObject.Find("Photo-inv");
        foreach (Transform GameOBJ in photoinv.transform)
        {
            if(GameOBJ.gameObject.TryGetComponent(out Picture Pic) )
            {
                if (Pic.PhotoID != 0)
                {
                    Piclist.Add(GameOBJ);
                }
            }
        }
        countingArray = Piclist.ToArray();


        for (int j = 0; j < countingArray.Length; j++)
        {
            for (int k = 0; k < countingArray.Length; k++)
            {
                if (j != k)
                {
                    if (countingArray[j].gameObject.GetComponent<Picture>().PhotoID == countingArray[k].gameObject.GetComponent<Picture>().PhotoID)
                    {
                        if (countingArray[j].gameObject.GetComponent<Picture>().value > countingArray[k].gameObject.GetComponent<Picture>().value)
                        {
                            countingArray[k].gameObject.GetComponent<Picture>().value = 0;
                        }
                        else
                        {
                            countingArray[j].gameObject.GetComponent<Picture>().value = 0;
                        }
                    }
                }
            }
        }

        for (int j = 0; j < countingArray.Length; j++)
        {
            result += countingArray[j].gameObject.GetComponent<Picture>().value;
        }

        result = result / GameObject.Find("Film (1)").GetComponent<Film>().Picnumber;

        print(result);

        ResultOverlay.SetActive(true);
        ResiltText.text = result.ToString();

        //delay this
        GameObject.Find("levelLoader").GetComponent<Levelloader>().DelayedLoad(2,2);
        staticDataHolder.currentTime++;
    }

}