using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture : MonoBehaviour
{
    [TextArea]
    [Tooltip("Doesn't do anything. Just comments shown in inspector")]
    public string Notes = "FILL IN THIS SHIT";
    [SerializeField] public int PhotoID = 0;
    [SerializeField] Sprite Fullpic;

    [Header("Value")]
    [Tooltip("THE GAME IS ALREADY BROKEN")]
    [SerializeField] public float Timer;
    //[Range(0, 10)]
    int time = 5;
    int time2 = 5;
    [SerializeField] public double percent1;
    [SerializeField] public double percent2;
    [SerializeField] public double percent3;
    [SerializeField] public double percent4;
    [SerializeField] public int value;

    [Header("Cursor")]
    public Texture2D Normal;
    public Texture2D Interactable;
    public Texture2D hold;

    [Header("FindOnStart")]
    [SerializeField] private GameObject gaemhander;
    [SerializeField] private GameObject invent;
    [SerializeField] private Animator animator;
    [SerializeField] private Vector2 innitialpos;


    [SerializeField] private float offsetY = 0.7f;

    [Header("UpdateIngame")]
    [SerializeField] public bool locked;
    private Vector2 mouseposition;
    private float deltaX, deltaY;
    private float motiontime;

    [SerializeField] bool FirstTray = false;
    [SerializeField] bool secondtray = false;
    [SerializeField] bool thirdtray = false;
    [SerializeField] bool hangable = false;
    bool oninv;
    [SerializeField] private float onhold = 0; //holdingpic or not
    [SerializeField] bool Hanged = false;
    [SerializeField] GameObject PastPos;
    [SerializeField] public bool isholding = false;
    GameObject imagepre;
    public bool Trash = false;
    /*
    [Header("Data")]
    public Sprite Blur;
    */


    void Start()  //X 3.45- 7.83 Y -2.92 2.94
    {
        Cursor.SetCursor(Normal, Vector2.zero, CursorMode.ForceSoftware);
        innitialpos = transform.position;
        animator = gameObject.GetComponent<Animator>();
        gaemhander =  GameObject.Find("Event controller");
        invent = GameObject.Find("Photo-inv");
        imagepre = GameObject.Find("ImagePreview");

    }


    void OnMouseEnter()
    {
        Cursor.SetCursor(Interactable, Vector2.zero, CursorMode.ForceSoftware);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(Normal, Vector2.zero, CursorMode.ForceSoftware);
    }

    void Hold()
    {
        if (isholding)
        {
            Cursor.SetCursor(hold, Vector2.zero, CursorMode.ForceSoftware);
            if (!locked)
            {
                setlayer(200);
                
                transform.SetParent(GameObject.Find("Bunch of pics").transform, true);
                mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector2(mouseposition.x - deltaX, mouseposition.y - deltaY);

                FindObjectOfType<Mechine>().holdingitem = true;

                if (Trash)
                {
                    FindObjectOfType<Navigator>().Enable("Trash", true);
                }
                else if (!FirstTray)
                {
                    FindObjectOfType<Navigator>().Enable("Tray1",true);
                }
                else if (!secondtray)
                {
                    FindObjectOfType<Navigator>().Enable("Tray2", true);
                }
                else if (!thirdtray)
                {
                    FindObjectOfType<Navigator>().Enable("Tray3", true);
                }
                else if (hangable && !Hanged)
                {
                    FindObjectOfType<Navigator>().Enable("Hang", true);
                }
                else if (Hanged)
                {
                    FindObjectOfType<Navigator>().Enable("Place", true);
                }
                    
            }
        }
    }

    void OnMouseDown()
    {
        Cursor.SetCursor(Normal, Vector2.zero, CursorMode.ForceSoftware);

        if (!locked)
        {
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    void OnMouseUp()
    {
        if (!locked)
        {
            isholding = false;
            Cursor.SetCursor(Normal, Vector2.zero, CursorMode.ForceSoftware);
            if (!Hanged && !Trash)
            {
                returelayer();
                if (gaemhander.GetComponent<Game_handler>().mouseonTray1 && gaemhander.GetComponent<Game_handler>().placable && !secondtray && !thirdtray && !hangable) //first tray
                {

                    transform.position = new Vector2(gaemhander.GetComponent<Game_handler>().currentmouseon.transform.position.x, gaemhander.GetComponent<Game_handler>().currentmouseon.transform.position.y);
                    animator.SetTrigger("place");
                    FirstTray = true;
                    gaemhander.GetComponent<Game_handler>().currentmouseon.GetComponent<Item_with_slot>().ObjectIN = this.gameObject; //THIS

                    PastPos = gaemhander.GetComponent<Game_handler>().currentmouseon;
                    PastPos.GetComponent<Item_with_slot>().Locked = true;

                    innitialpos = transform.position;
                    gaemhander.GetComponent<Game_handler>().SoundManager.GetComponent<SoundManager>().PlayFX(0);
                }
                else if (gaemhander.GetComponent<Game_handler>().mouseonTray2 && FirstTray && gaemhander.GetComponent<Game_handler>().placable && !thirdtray && !secondtray && !hangable) //second tray
                {
                    if (PastPos.TryGetComponent(out Item_with_slot Tray))
                    {
                        Tray.Locked = false;
                    }

                    if (!secondtray)
                    {
                        Timer = 0;
                    }

                    transform.position = new Vector2(gaemhander.GetComponent<Game_handler>().currentmouseon.transform.position.x, gaemhander.GetComponent<Game_handler>().currentmouseon.transform.position.y);
                    secondtray = true;
                    gaemhander.GetComponent<Game_handler>().currentmouseon.GetComponent<Item_with_slot>().ObjectIN = this.gameObject; //THIS

                    PastPos = gaemhander.GetComponent<Game_handler>().currentmouseon;
                    PastPos.GetComponent<Item_with_slot>().Locked = true;

                    innitialpos = transform.position;
                    gaemhander.GetComponent<Game_handler>().SoundManager.GetComponent<SoundManager>().PlayFX(0);
                }
                else if (gaemhander.GetComponent<Game_handler>().mouseonTray3 && secondtray && gaemhander.GetComponent<Game_handler>().placable && !hangable) //third tray
                {
                    if (PastPos.TryGetComponent(out Item_with_slot Tray))
                    {
                        Tray.Locked = false;
                    }

                    if (!thirdtray)
                    {
                        Timer = 0;
                    }

                    transform.position = new Vector2(gaemhander.GetComponent<Game_handler>().currentmouseon.transform.position.x, gaemhander.GetComponent<Game_handler>().currentmouseon.transform.position.y);
                    thirdtray = true;
                    gaemhander.GetComponent<Game_handler>().currentmouseon.GetComponent<Item_with_slot>().ObjectIN = this.gameObject; //THis

                    PastPos = gaemhander.GetComponent<Game_handler>().currentmouseon;
                    PastPos.GetComponent<Item_with_slot>().Locked = true;

                    innitialpos = transform.position;
                    hangable = true;
                    gaemhander.GetComponent<Game_handler>().SoundManager.GetComponent<SoundManager>().PlayFX(0);
                }
                else if (hangable && gaemhander.GetComponent<Game_handler>().placable && gaemhander.GetComponent<Game_handler>().currentmouseon.CompareTag("Hanger")) //Hanger
                {

                    if (PastPos.TryGetComponent(out Item_with_slot Tray))
                    {
                        Tray.Locked = false;
                    }

                    Timer = 0;

                    transform.position = new Vector2(gaemhander.GetComponent<Game_handler>().currentmouseon.transform.position.x, gaemhander.GetComponent<Game_handler>().currentmouseon.transform.position.y - offsetY);
                    value = (int)(percent1 + percent2 + percent3) / 3;
                    Hanged = true;
                    PastPos = gaemhander.GetComponent<Game_handler>().currentmouseon;
                    PastPos.GetComponent<Item_with_slot>().ObjectIN = this.gameObject;
                    PastPos.GetComponent<Item_with_slot>().Locked = true;
                    innitialpos = transform.position;
                    gaemhander.GetComponent<Game_handler>().SoundManager.GetComponent<SoundManager>().PlayFX(3);

                    //gaemhander.GetComponent<Game_handler>().respawn();

                }
                //-------------------------placable

                /*else if (transform.position.x > 3.45 && transform.position.x < 7.83 && transform.position.y > -2.92 && transform.position.y < 2.94)
                {       
                    innitialpos = transform.position;
                }*/

                //-------------------------

                else if (oninv && Hanged) //on inventory
                {
                    setlayer(101);
                    transform.SetParent(invent.transform, true);
                }

                //-------------------------
                else //go back to original pos
                {
                    if (PastPos != null)
                    {
                        if (PastPos.TryGetComponent(out Item_with_slot ite))
                        {
                            ite.ObjectIN = this.gameObject;
                            ite.Locked = true;
                        }
                    }
                    transform.position = new Vector2(innitialpos.x, innitialpos.y);
                }

            }
            else
            {
                /*
                if (gaemhander.GetComponent<Game_handler>().placable)
                {
                    print("slotted");
                    setlayer(103);
                    invent = gaemhander.GetComponent<Game_handler>().currentmouseon;
                    transform.SetParent(invent.transform, true);
                    transform.position = new Vector2(gaemhander.GetComponent<Game_handler>().currentmouseon.transform.position.x, gaemhander.GetComponent<Game_handler>().currentmouseon.transform.position.y);

                    PastPos.GetComponent<hanger>().Locked = false;
                    gaemhander.GetComponent<Game_handler>().currentmouseon.GetComponent<slotInv>().slotted = true;
                    locked = true;
                }*/
                if (oninv && !Trash) //on inventory
                {
                    setlayer(101);
                    innitialpos = transform.position;
                    transform.SetParent(invent.transform, true);
                    PastPos.GetComponent<Item_with_slot>().Locked = false;
                }
                else
                {
                    //transform.SetParent(invent.transform, true);
                    transform.position = new Vector2(innitialpos.x, innitialpos.y);
                }

            }
            FindObjectOfType<Navigator>().Enable("Trash", false);
            FindObjectOfType<Navigator>().Enable("Tray1", false);
            FindObjectOfType<Navigator>().Enable("Tray2", false);
            FindObjectOfType<Navigator>().Enable("Tray3", false);
            FindObjectOfType<Navigator>().Enable("Hang", false);
            FindObjectOfType<Navigator>().Enable("Place", false);
            FindObjectOfType<Mechine>().holdingitem = false;
        }
    }
    void Update()
    {
        Hold();
        timerUpdate();

        if (Trash)
        {
            animator.SetFloat("progress", 1);
            transform.Find("75134282_p0_master1200_2").GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
        }

        /*
        if (!FirstTray&& !secondtray && !thirdtray)
        {
            if (motiontime > 0f)
            {
                motiontime = 0f;
            }
        }
        else if (FirstTray && !secondtray && !thirdtray)
        {
            if (motiontime > 0.3f)
            {
                motiontime = 0.3f;
            }
        }
        else if (FirstTray && secondtray && !thirdtray)
        {
            if (motiontime > 0.6f)
            {
                motiontime = 0.6f;
            }
        }
        else if (FirstTray && secondtray && thirdtray)
        {
            if (motiontime > 1f)
            {
                motiontime = 1f;
            }
        }

        motiontime += Time.deltaTime/10;
        */
        motiontime = (float)((percent1 + percent2 + percent3) / 300);
        animator.SetFloat("progress", motiontime);

        //----------------------------------
        oninv = gaemhander.GetComponent<Game_handler>().mouseonINV;

    }

    void OnMouseOver()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            imagepre.GetComponent<SpriteRenderer>().sprite = Fullpic;
            imagepre.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f, transform.Find("75134282_p0_master1200_2").GetComponent<SpriteRenderer>().color.a);
        }
        else
        {
            imagepre.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        }
    }

    void setlayer(int layer)
    {
        if (onhold == 0)
        {
            int children = transform.childCount;
            for (int i = 0; i < children; ++i)
            {
                transform.GetChild(i).GetComponent<Picpart>().setlayer(layer);
                transform.GetChild(i).GetComponent<SpriteRenderer>().sortingLayerName = "OnHold";
            }
            onhold = 1;
        }
    }

    void returelayer()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            transform.GetChild(i).GetComponent<Picpart>().returnlayer();
            transform.GetChild(i).GetComponent<SpriteRenderer>().sortingLayerName = "Dafault";
        }
        onhold = 0;
    }

    void timerUpdate()
    {
        //Need to reset the value when enter new tray
        if (!Hanged &&!isholding && !Trash)
        {
            float seconds = Timer % 60;

            if (thirdtray)
            {
                Timer += Time.deltaTime;
                percent3 = (seconds / time) * 100;
            }
            else if (secondtray)
            {
                Timer += Time.deltaTime;
                percent2 = (seconds / time) * 100;
            }
            else if (FirstTray)
            {
                Timer += Time.deltaTime;
                percent1 = (seconds / time)*100;
            }

        }
        else if (Hanged)
        {
            float seconds = Timer % 60;
            Timer += Time.deltaTime;
            percent4 = (seconds / time2) * 100;
            if (percent4 < 100)
            {
                locked = true;
            }
            else
            {
                locked = false;
            }
        }

    }

}
