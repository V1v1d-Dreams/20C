using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture : MonoBehaviour
{
    [SerializeField] private float offsetY = 0.7f;

    public Texture2D Normal;
    public Texture2D Interactable;
    public Texture2D hold;

    private Animator animator;

    private Vector2 innitialpos;
    [SerializeField] private bool locked;

    [SerializeField] private Transform targetpos1;
    [SerializeField] private Transform targetpos2;
    [SerializeField] private Transform targetpos3;
    [SerializeField] private Transform targetpos4;
    [SerializeField] private Transform targetpos5;
    private Vector2 mouseposition;
    private float deltaX, deltaY;

    [SerializeField] private float motiontime;

    bool FirstTray = false;
    bool secondtray = false;
    bool thirdtray = false;
    bool hangable = false;

    [SerializeField] private GameObject gaemhander;
    [SerializeField] private GameObject invent;
    bool oninv;
    Picpart[] Pics;

    private float onhold = 0;

    // Start is called before the first frame update
    void Start()  //X 3.45- 7.83 Y -2.92 2.94
    {
        Cursor.SetCursor(Normal, Vector2.zero, CursorMode.ForceSoftware);
        innitialpos = transform.position;
        animator = gameObject.GetComponent<Animator>();
        gaemhander =  GameObject.Find("Event controller");
        invent = GameObject.Find("Photo-inv");
        targetpos1 = GameObject.Find("Tray1").transform;
        targetpos2 = GameObject.Find("Tray2").transform;
        targetpos3 = GameObject.Find("Tray3").transform;
        targetpos4 = GameObject.Find("Hangspot1").transform;
        targetpos5 = GameObject.Find("Hangspot2").transform;


    }


    void OnMouseEnter()
    {
        Cursor.SetCursor(Interactable, Vector2.zero, CursorMode.ForceSoftware);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(Normal, Vector2.zero, CursorMode.ForceSoftware);
    }

    void OnMouseDrag()
    {
        setlayer(200);
        transform.SetParent(GameObject.Find("Bunch of pics").transform, true);
        Cursor.SetCursor(hold, Vector2.zero, CursorMode.ForceSoftware);
        if (!locked)
        {
            mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mouseposition.x - deltaX, mouseposition.y - deltaY);
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
        returelayer();
        Cursor.SetCursor(Normal, Vector2.zero, CursorMode.ForceSoftware);

        if (Mathf.Abs(transform.position.x - targetpos1.position.x) <= 0.5f &&
            Mathf.Abs(transform.position.y - targetpos1.position.y) <= 0.5f)
        {
            transform.position = new Vector2(targetpos1.position.x, targetpos1.position.y);
            animator.SetTrigger("place");
            FirstTray = true;
            innitialpos = transform.position;
        }
        else if ((Mathf.Abs(transform.position.x - targetpos2.position.x) <= 0.5f && Mathf.Abs(transform.position.y - targetpos2.position.y) <= 0.5f) && FirstTray) //second tray
        {
            transform.position = new Vector2(targetpos2.position.x, targetpos2.position.y);
            secondtray = true;
            innitialpos = transform.position;
        }
        else if ((Mathf.Abs(transform.position.x - targetpos3.position.x) <= 0.5f && Mathf.Abs(transform.position.y - targetpos3.position.y) <= 0.5f) && secondtray) //third tray
        {
            transform.position = new Vector2(targetpos3.position.x, targetpos3.position.y);
            thirdtray = true;
            innitialpos = transform.position;
            hangable = true;
        }
        else if ((Mathf.Abs(transform.position.x - targetpos4.position.x) <= 0.5f && Mathf.Abs(transform.position.y - targetpos4.position.y) <= 0.5f) && hangable) //hanger 1
        {
            print("lock");
            transform.position = new Vector2(targetpos4.position.x, targetpos4.position.y - offsetY);
            locked = true;
            innitialpos = transform.position;
            gaemhander.GetComponent<Game_handler>().respawn();
        }
        else if ((Mathf.Abs(transform.position.x - targetpos5.position.x) <= 0.5f && Mathf.Abs(transform.position.y - targetpos5.position.y) <= 0.5f) && hangable) //hanger 2
        {
            print("lock");
            transform.position = new Vector2(targetpos5.position.x, targetpos5.position.y - offsetY);
            locked = true;
            innitialpos = transform.position;
            gaemhander.GetComponent<Game_handler>().respawn();
        }
        else if (transform.position.x > 3.45 && transform.position.x < 7.83 && transform.position.y > -2.92 && transform.position.y < 2.94)
        {       
            innitialpos = transform.position;
        }
        else if (oninv)
        {
            setlayer(101);
            transform.SetParent(invent.transform, true);
        }
        else
        {
            transform.position = new Vector2(innitialpos.x, innitialpos.y);
        }
        
    }
    void Update()
    {
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
