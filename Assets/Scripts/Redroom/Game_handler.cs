using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_handler : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI paperNumBa;
    [SerializeField] public Camera cam;
    [SerializeField] GameObject film;
    [SerializeField] GameObject film2;
    [SerializeField] GameObject film3;
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
    [SerializeField] GameObject Hanger1;
    [SerializeField] GameObject Hanger2;
    [SerializeField] GameObject Hanger3;
    [SerializeField] GameObject TrayLv1;
    [SerializeField] GameObject TrayLv2;
    [SerializeField] GameObject ChemObj;
    [SerializeField] Sprite Chem1;
    [SerializeField] Sprite Chem2;
    [SerializeField] Sprite Chem3;
    [SerializeField] public int paperNum;
    [SerializeField] GameObject photopreview1;
    [SerializeField] GameObject photopreview2;
    [SerializeField] GameObject photopreview3;
    [SerializeField] GameObject List;
    [SerializeField] GameObject Guidebook;
    [SerializeField] PhotoinfilmCheck photoFCheck;
    [SerializeField] Sprite[] Guildsprites;
    [SerializeField] int GuideIndex;
    [SerializeField] Image guildpic;

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
    [SerializeField] public float PicDevDuration;
    [SerializeField] public float PicTimeWindows;

    //[Header("campos")]
    //[SerializeField] public int[] CamPosittion;
    //[SerializeField] public int CurrentCamPos = 1;

    [Header("Bool")]
    [SerializeField] public bool overlay = false;

    [Header("Tutorial")]
    [SerializeField] TMPro.TextMeshProUGUI Text1;
    [SerializeField] GameObject exitbutton;
    [SerializeField] GameObject overlayy;
    [SerializeField] Image img;
    [SerializeField] GameObject Mechine;
    [SerializeField] GameObject Hanger;
    [SerializeField] GameObject paperItem;
    [SerializeField] GameObject PaperDrag;
    [SerializeField] GameObject filmItem;
    [SerializeField] GameObject filmItem2;
    [SerializeField] GameObject filmItem3;
    [SerializeField] GameObject Tray1Item;
    [SerializeField] GameObject Tray2Item;
    [SerializeField] GameObject Tray3Item;
    [SerializeField] GameObject photoTray;
    [SerializeField] GameObject ListItem;
    [SerializeField] GameObject GuideItem;



    [Header("Tutorial Bool")]
    [SerializeField] public bool FilmInEnlarger = false;
    [SerializeField] public bool PaperInEnlarger = false;
    [SerializeField] public bool PhotoProcessed = false;
    [SerializeField] public bool Tray1Click = false;
    [SerializeField] public bool Tray3Click = false;
    [SerializeField] public bool PhotoDried = false;

    //[SerializeField] SpriteRenderer Film1;
    //[SerializeField] SpriteRenderer Film2;
    //[SerializeField] SpriteRenderer Film3;
    [TextArea(2, 3)]
    [SerializeField] string[] strings;
    int stringIndex = 0;

    RaycastHit2D[] raycast;
    RaycastHit2D[] Click;
    void Start()
    {
        //cam_follow_pos = cam.transform.position;
        Magnifier_Lv = staticDataHolder.mechinelv;
        Hanger_Lv = staticDataHolder.hangerLv;

        if (staticDataHolder.Todaysfilm == null)
        {
            film.SetActive(false);
            //Film1.enabled = false;
        }
        if (staticDataHolder.Todaysfilm2 == null)
        {
            film2.SetActive(false);
            //Film2.enabled = false;
        }
        if (staticDataHolder.Todaysfilm3 == null)
        {
            film3.SetActive(false);
            //Film3.enabled = false;
        }

        if (!staticDataHolder.finishedtutorial)
        {
            exitbutton.SetActive(false);
            Text1.enabled = true;
            overlayy.SetActive(true);
            img.enabled = true;
            //overlay = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            staticDataHolder.papernumber += 5;
        }
        
        if (!staticDataHolder.finishedtutorial)
        {
            
            if (stringIndex < strings.Length)
            {
                switch (stringIndex)
                {
                    case 0:
                        Text1.text = strings[stringIndex];
                        if (Input.GetMouseButtonUp(0))
                        {
                            stringIndex++;
                        }
                        break;
                    case 1: 
                        Text1.text = strings[stringIndex]; //let’s drag a film into it.                                      Highlight mechine and All film

                        Mechine.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
                        Mechine.GetComponent<SpriteRenderer>().sortingOrder = 501;

                        Film[] FiLm = FindObjectsOfType<Film>();
                        for (int i = FiLm.Length - 1; i >= 0; i--)
                        {
                            FiLm[i].setlayer(502, "UI");
                        }

                        if (FilmInEnlarger) // trigger when Film In
                        {
                            stringIndex++;
                        }
                        break;
                    case 2:
                        Text1.text = strings[stringIndex]; //photo paper underneath it                                       Highlight Paper

                        Film[] FiLM = FindObjectsOfType<Film>();
                        for (int i = FiLM.Length - 1; i >= 0; i--)
                        {
                            FiLM[i].returelayer();
                        }

                        paperItem.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
                        paperItem.GetComponent<SpriteRenderer>().sortingOrder = 501;

                        PaperDrag.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
                        PaperDrag.GetComponent<SpriteRenderer>().sortingOrder = 501;

                        if (PaperInEnlarger) // trigger when Paper in
                        {
                            stringIndex++;
                        }
                        break;
                    case 3:
                        Text1.text = strings[stringIndex]; // look into its sight and transfer Photo                         Highlight Nothing

                        paperItem.GetComponent<SpriteRenderer>().sortingLayerName = "items";
                        paperItem.GetComponent<SpriteRenderer>().sortingOrder = 2;

                        PaperDrag.GetComponent<SpriteRenderer>().sortingLayerName = "Layer1";
                        PaperDrag.GetComponent<SpriteRenderer>().sortingOrder = 106;

                        if (PhotoProcessed) // trigger when Pic Processed
                        {
                            stringIndex++;
                        }
                        break;
                    case 4: //EVERY TRAY WILL STOP AT GREEN
                        Text1.text = strings[stringIndex]; //put it into these 3 trays                                       Highlight Trays + EveryPic

                        Tray1Item.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
                        Tray1Item.GetComponent<SpriteRenderer>().sortingOrder = 501;
                        Tray2Item.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
                        Tray2Item.GetComponent<SpriteRenderer>().sortingOrder = 501;
                        Tray3Item.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
                        Tray3Item.GetComponent<SpriteRenderer>().sortingOrder = 501;

                        Picture[] pIx = FindObjectsOfType<Picture>();
                        for (int i = pIx.Length - 1; i >= 0; i--)
                        {
                            pIx[i].setlayer(502, "UI");
                        }

                        if (Tray1Click) // trigger when tray1 at green
                        {
                            stringIndex++;
                        }
                        break;
                    case 5: 
                        Text1.text = strings[stringIndex]; //too long unless the paper will get too moist                    Highlight Trays + EveryPic
                        if (Tray3Click) // trigger when Tray3 Green 
                        {
                            stringIndex++; 
                        }
                        break;
                    case 6: 
                        Text1.text = strings[stringIndex]; //hang your photo                                                 Highlight Hanger + EveryPic

                        Tray1Item.GetComponent<SpriteRenderer>().sortingLayerName = "items";
                        Tray1Item.GetComponent<SpriteRenderer>().sortingOrder = 0;

                        Tray2Item.GetComponent<SpriteRenderer>().sortingLayerName = "items";
                        Tray2Item.GetComponent<SpriteRenderer>().sortingOrder = 0;

                        Tray3Item.GetComponent<SpriteRenderer>().sortingLayerName = "items";
                        Tray3Item.GetComponent<SpriteRenderer>().sortingOrder = 0;

                        if (PhotoDried) // trigger when Photo dried
                        {
                            stringIndex++; 
                        }
                        break;
                    case 7: 
                        Text1.text = strings[stringIndex]; // Put it into this tray                                          Highlight FinishTray + EveryPic

                        photoTray.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
                        photoTray.GetComponent<SpriteRenderer>().sortingOrder = 501;

                        if (Input.GetMouseButtonUp(0))
                        {
                            stringIndex++;
                        }
                        break;
                    case 8:
                        Text1.text = strings[stringIndex]; //That’s easy right                                               Highlight Nothing

                        photoTray.GetComponent<SpriteRenderer>().sortingLayerName = "items";
                        photoTray.GetComponent<SpriteRenderer>().sortingOrder = 2;

                        Picture[] pIX = FindObjectsOfType<Picture>();
                        for (int i = pIX.Length - 1; i >= 0; i--)
                        {
                            pIX[i].returelayer();
                        }

                        if (Input.GetMouseButtonUp(0))
                        {
                            stringIndex++;
                        }
                        break;
                    case 9: 
                        Text1.text = strings[stringIndex]; //don’t forget to write down the order                            Highlight List

                        ListItem.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
                        ListItem.GetComponent<SpriteRenderer>().sortingOrder = 501;

                        if (Input.GetMouseButtonUp(0))
                        {
                            stringIndex++;
                        }
                        break;
                    case 10: 
                        Text1.text = strings[stringIndex]; // this is the guide book                                         Highlight Guide

                        GuideItem.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
                        GuideItem.GetComponent<SpriteRenderer>().sortingOrder = 501;

                        ListItem.GetComponent<SpriteRenderer>().sortingLayerName = "items";
                        ListItem.GetComponent<SpriteRenderer>().sortingOrder = 0;

                        if (Input.GetMouseButtonUp(0))
                        {
                            stringIndex++;

                            GuideItem.GetComponent<SpriteRenderer>().sortingLayerName = "items";
                            GuideItem.GetComponent<SpriteRenderer>().sortingOrder = 0;
                        }
                        break;
                }



            }
            else
            {
                //exitbutton.SetActive(true);

                Text1.enabled = false;
                overlayy.SetActive(false);
                img.enabled = false;
                //overlay = false;
            }
            

            
            //if (stringIndex < strings.Length)
            //{
            //    if (Input.GetMouseButtonUp(0))
            //    {
            //        stringIndex++;
            //        Text1.text = strings[stringIndex];
            //    }
            //}
            //else
            //{
            //    //exitbutton.SetActive(true);
            //    Text1.enabled = false;
            //    overlayy.SetActive(false);
            //    img.enabled = false;
            //    overlay = false;
            //}


            //if (stringIndex ==1)
            //{
            //    Mechine.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
            //    Mechine.GetComponent<SpriteRenderer>().sortingOrder = 501;
            //}
            //else
            //{
            //    Mechine.GetComponent<SpriteRenderer>().sortingLayerName = "items";
            //    Mechine.GetComponent<SpriteRenderer>().sortingOrder = 0;
            //}

            //if (stringIndex == 2)
            //{
            //    paperItem.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
            //    paperItem.GetComponent<SpriteRenderer>().sortingOrder = 501;
            //    filmItem.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
            //    filmItem.GetComponent<SpriteRenderer>().sortingOrder = 501;
            //    filmItem2.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
            //    filmItem2.GetComponent<SpriteRenderer>().sortingOrder = 501;
            //    filmItem3.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
            //    filmItem3.GetComponent<SpriteRenderer>().sortingOrder = 501;
            //}
            //else
            //{
            //    paperItem.GetComponent<SpriteRenderer>().sortingLayerName = "items";
            //    paperItem.GetComponent<SpriteRenderer>().sortingOrder = 2;
            //    filmItem.GetComponent<SpriteRenderer>().sortingLayerName = "items2";
            //    filmItem.GetComponent<SpriteRenderer>().sortingOrder = 3;
            //    filmItem2.GetComponent<SpriteRenderer>().sortingLayerName = "items2";
            //    filmItem2.GetComponent<SpriteRenderer>().sortingOrder = 3;
            //    filmItem3.GetComponent<SpriteRenderer>().sortingLayerName = "items2";
            //    filmItem3.GetComponent<SpriteRenderer>().sortingOrder = 3;
            //}

            //if (stringIndex == 3|| stringIndex == 4)
            //{
            //    Tray1Item.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
            //    Tray1Item.GetComponent<SpriteRenderer>().sortingOrder = 501;
            //    Tray2Item.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
            //    Tray2Item.GetComponent<SpriteRenderer>().sortingOrder = 501;
            //    Tray3Item.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
            //    Tray3Item.GetComponent<SpriteRenderer>().sortingOrder = 501;
            //}
            //else
            //{
            //    Tray1Item.GetComponent<SpriteRenderer>().sortingLayerName = "items";
            //    Tray1Item.GetComponent<SpriteRenderer>().sortingOrder = 0;

            //    Tray2Item.GetComponent<SpriteRenderer>().sortingLayerName = "items";
            //    Tray2Item.GetComponent<SpriteRenderer>().sortingOrder = 0;

            //    Tray3Item.GetComponent<SpriteRenderer>().sortingLayerName = "items";
            //    Tray3Item.GetComponent<SpriteRenderer>().sortingOrder = 0;
            //}

            //if (stringIndex == 5)
            //{
            //    Hanger.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
            //    Hanger.GetComponent<SpriteRenderer>().sortingOrder = 501;
            //}
            //else
            //{
            //    Hanger.GetComponent<SpriteRenderer>().sortingLayerName = "items";
            //    Hanger.GetComponent<SpriteRenderer>().sortingOrder = -1;
            //}

            //if (stringIndex == 6)
            //{
            //    photoTray.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
            //    photoTray.GetComponent<SpriteRenderer>().sortingOrder = 501;
            //}
            //else
            //{
            //    photoTray.GetComponent<SpriteRenderer>().sortingLayerName = "items";
            //    photoTray.GetComponent<SpriteRenderer>().sortingOrder = 2;
            //}
            
        }

        paperNumBa.text = staticDataHolder.papernumber.ToString();

        UpdateLv();

        //Debug.Log(staticDataHolder.Todaysfilm.name);
        //Debug.Log(staticDataHolder.Todaysfilm2.name);

        switch (GameObject.Find("mechine").GetComponent<Mechine>().MechineFilmIn)
        {
            case Replacer.FilmNumber.One:
                ChangeFilm(staticDataHolder.Todaysfilm.GetComponent<Film>());
                break;
            case Replacer.FilmNumber.Two:
                ChangeFilm(staticDataHolder.Todaysfilm2.GetComponent<Film>());
                break;
            case Replacer.FilmNumber.Three:
                ChangeFilm(staticDataHolder.Todaysfilm3.GetComponent<Film>());
                break;
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
                    else if (Click[1].collider.gameObject.CompareTag("Paper"))
                    {
                        Click[1].collider.gameObject.GetComponent<Paper>().isholding = true;
                        print(Click[1].collider.gameObject.name);
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
                        GameObject.FindObjectOfType<RedroomNsoundmanager>().Bin();
                    }
                }

                if (!Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), transform.forward))
                {

                }
                else if (Click[0].collider.gameObject.TryGetComponent(out mechinebutton matbut))
                {
                    if (Input.GetMouseButtonUp(0))
                    {
                        matbut.StartButtonpress();
                    }

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
                else if (Click[0].collider.gameObject.name == "list")
                {
                    photoFCheck.Checkphoto();
                    List.SetActive(true);
                    overlay = true;
                }
                else if (Click[0].collider.gameObject.name == "book")
                {
                    Guidebook.SetActive(true);
                    overlay = true;
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
                Click = Physics2D.RaycastAll(cam.ScreenToWorldPoint(Input.mousePosition), transform.forward);
                if (Click[0])
                {
                    Click[0].collider.gameObject.GetComponent<Paper>().mouseOnPaper = true;
                    if (Input.GetMouseButtonUp(0) && ((staticDataHolder.papernumber - 1) >= 0))
                    {
                        GameObject.Find("mechine").GetComponent<Mechine>().paperin = true;
                        if (!staticDataHolder.finishedtutorial)
                        {
                            FindObjectOfType<Game_handler>().PaperInEnlarger = true;
                            print("PaperIntuto");
                        }
                    }
                }
                break;
            }
            else if (raycast[i].collider.gameObject.CompareTag("Film"))
            {
                //print("mouse Onfilm");
                Click = Physics2D.RaycastAll(cam.ScreenToWorldPoint(Input.mousePosition), transform.forward);
                if (Click[0])
                {
                    if (Click[0].collider.gameObject.TryGetComponent(out Film film))
                    {
                        film.mouseOnfilm = true;
                        Debug.Log("Gamehander :" + film.mouseOnfilm);
                    }
                    /*
                    else if (Click[1].collider.gameObject.TryGetComponent(out Film fIlm))
                    {
                        fIlm.mouseOnfilm = true;
                        Debug.Log("Gamehander :" + fIlm.mouseOnfilm);
                    }
                    */
                }


                if (Input.GetMouseButtonUp(0))
                {
                    //transform.position = new Vector2(innitialpos.x, innitialpos.y);
                    //GameObject.Find("mechine").GetComponent<Mechine>().filmin = true;
                    //GameObject.Find("mechine").GetComponent<Mechine>().smolpic.GetComponent<SmoLpic>().pic = Click[0].collider.gameObject.GetComponent<Film>().picturearray;
                    //GameObject.Find("mechine").GetComponent<Mechine>().smolpic.GetComponent<SmoLpic>().Smol = Click[0].collider.gameObject.GetComponent<Film>().BlurArray;
                    
                    //SoundManager.GetComponent<SoundManager>().PlayFX(1);
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

    void UpdateLv()
    {
        if (Input.GetKeyUp(KeyCode.O))
        {
            Magnifier_Lv += 1;
            Hanger_Lv += 1;
            staticDataHolder.mechinelv += 1;
            staticDataHolder.hangerLv += 1;
            staticDataHolder.chemlv += 1;
            staticDataHolder.tray = !staticDataHolder.tray;
        }

        switch (Hanger_Lv)
        {
            case 1:
                Hanger1.SetActive(true);
                //Hanger2.SetActive(true);
                //Hanger3.SetActive(true);
                break;
            case 2:
                Hanger1.SetActive(true);
                Hanger2.SetActive(true);
                //Hanger3.SetActive(true);
                break;
            case 3:
                Hanger1.SetActive(true);
                Hanger2.SetActive(true);
                Hanger3.SetActive(true);
                break;
            default:
                Hanger1.SetActive(true);
                Hanger2.SetActive(true);
                Hanger3.SetActive(true);
                break;
        }

        switch (staticDataHolder.tray)
        {
            case false:
                TrayLv1.SetActive(true);
                TrayLv2.SetActive(false);
                break;
            case true:
                TrayLv1.SetActive(false);
                TrayLv2.SetActive(true);
                break;
        }

        switch (staticDataHolder.chemlv)
        {
            case 1:
                ChemObj.GetComponent<SpriteRenderer>().sprite = Chem1;
                PicDevDuration = 8;
                PicTimeWindows = 15;
                break;
            case 2:
                ChemObj.GetComponent<SpriteRenderer>().sprite = Chem2;
                PicDevDuration = 5;
                PicTimeWindows = 15;
                break;
            case 3:
                ChemObj.GetComponent<SpriteRenderer>().sprite = Chem3;
                PicDevDuration = 6;
                PicTimeWindows = 30;
                break;
            default:
                ChemObj.GetComponent<SpriteRenderer>().sprite = Chem3;
                PicDevDuration = 6;
                PicTimeWindows = 30;
                break;
        }

    }

    public void ChangeFilm(Film Infilm)
    {
        if (staticDataHolder.mechinelv == 1)
        {
            photopreview1.GetComponent<SpriteRenderer>().sprite = Infilm.FilmSprite;
        }
        else if (staticDataHolder.mechinelv == 2)
        {
            photopreview2.GetComponent<SpriteRenderer>().sprite = Infilm.FilmSprite;
        }
        else
        {
            photopreview3.GetComponent<SpriteRenderer>().sprite = Infilm.FilmSprite;
        }

        //pic = Infilm.picturearray;
    }

    public void ExitList()
    {
        overlay = false;
        List.SetActive(false);
    }

    public void ExitGuide()
    {
        overlay = false;
        Guidebook.SetActive(false);
    }

    public void Guildchnagesprite(bool Leftpage)
    {
        if (Leftpage)
        {
            if (GuideIndex > 0) 
            {
                GuideIndex -= 1;
                guildpic.sprite = Guildsprites[GuideIndex];
            }
            //guildpic
             
        }
        else
        {
            if (GuideIndex < Guildsprites.Length)
            {
                GuideIndex += 1;
                guildpic.sprite = Guildsprites[GuideIndex];
            }
        }
    }
}
