using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture : MonoBehaviour
{
    [TextArea]
    [Tooltip("Doesn't do anything. Just comments shown in inspector")]
    public string Notes = "FILL IN THIS SHIT";

    [Header("Value")]
    [Tooltip("FUCKING PUT THIS IN OR ELSE THE GAME WILL BROKE")]
    [SerializeField] public float Value;

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
    [SerializeField] private bool locked;
    private Vector2 mouseposition;
    private float deltaX, deltaY;
    private float motiontime;

    bool FirstTray = false;
    bool secondtray = false;
    bool thirdtray = false;
    [SerializeField] bool hangable = false;
    bool oninv;
    [SerializeField] private float onhold = 0; //holdingpic or not
    [SerializeField] bool Hanged = false;
    [SerializeField] GameObject PastPos;
    [SerializeField] public bool isholding = false;

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
        isholding = false;
        Cursor.SetCursor(Normal, Vector2.zero, CursorMode.ForceSoftware);

        if (!Hanged)
        {
            returelayer();
            if (gaemhander.GetComponent<Game_handler>().mouseonTray1) //first tray
            {
                transform.position = new Vector2(gaemhander.GetComponent<Game_handler>().currentmouseon.transform.position.x, gaemhander.GetComponent<Game_handler>().currentmouseon.transform.position.y);
                animator.SetTrigger("place");
                FirstTray = true;
                innitialpos = transform.position;
            }
            else if (gaemhander.GetComponent<Game_handler>().mouseonTray2 && FirstTray) //second tray
            {
                transform.position = new Vector2(gaemhander.GetComponent<Game_handler>().currentmouseon.transform.position.x, gaemhander.GetComponent<Game_handler>().currentmouseon.transform.position.y);
                secondtray = true;
                innitialpos = transform.position;
            }
            else if (gaemhander.GetComponent<Game_handler>().mouseonTray3 && secondtray) //third tray
            {
                transform.position = new Vector2(gaemhander.GetComponent<Game_handler>().currentmouseon.transform.position.x, gaemhander.GetComponent<Game_handler>().currentmouseon.transform.position.y);
                thirdtray = true;
                innitialpos = transform.position;
                hangable = true;
            }
            else if (hangable && gaemhander.GetComponent<Game_handler>().placable) //Hanger
            {
                transform.position = new Vector2(gaemhander.GetComponent<Game_handler>().currentmouseon.transform.position.x, gaemhander.GetComponent<Game_handler>().currentmouseon.transform.position.y - offsetY);
                Hanged = true;
                PastPos = gaemhander.GetComponent<Game_handler>().currentmouseon;
                PastPos.GetComponent<hanger>().Locked = true;
                innitialpos = transform.position;

                //gaemhander.GetComponent<Game_handler>().respawn();

            }
            //-------------------------placable

            /*else if (transform.position.x > 3.45 && transform.position.x < 7.83 && transform.position.y > -2.92 && transform.position.y < 2.94)
            {       
                innitialpos = transform.position;
            }*/

            //-------------------------

            /*else if (oninv) //on inventory
            {
                setlayer(101);
                transform.SetParent(invent.transform, true);
            }*/

            //-------------------------
            else //go back to original pos
            {
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
            if (oninv) //on inventory
            {
                setlayer(101);
                innitialpos = transform.position;
                transform.SetParent(invent.transform, true);
                PastPos.GetComponent<hanger>().Locked = false;
            }
            else
            {
                transform.SetParent(invent.transform, true);
                transform.position = new Vector2(innitialpos.x, innitialpos.y);
            }
        }
    }
    void Update()
    {
        Hold();

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
        animator.SetFloat("progress", motiontime);

        //----------------------------------
        oninv = gaemhander.GetComponent<Game_handler>().mouseonINV;

    }

    void setlayer(int layer)
    {
        if (onhold == 0)
        {
            int children = transform.childCount;
            for (int i = 0; i < children; ++i)
            {
                transform.GetChild(i).GetComponent<Picpart>().setlayer(layer);
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
        }
        onhold = 0;
    }
}
