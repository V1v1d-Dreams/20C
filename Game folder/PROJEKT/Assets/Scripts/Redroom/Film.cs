﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Film : MonoBehaviour
{
    public Texture2D Normal;
    public Texture2D Interactable;
    public Texture2D hold;

    private Vector2 innitialpos;
    private bool locked;

    [SerializeField] private Transform targetpos1;
    private Vector2 mouseposition;
    private float deltaX, deltaY;

    [SerializeField] private GameObject gaemhander;
    [SerializeField] private GameObject invent;
    bool oninv;

    [SerializeField] GameObject[] picturearray;
    [SerializeField] Sprite[] BlurArray;

    RaycastHit2D[] raycast;
    private Camera cam;
    [SerializeField] private bool mouseOnfilm;


    // Start is called before the first frame update
    void Start() 
    {
        Cursor.SetCursor(Normal, Vector2.zero, CursorMode.ForceSoftware);
        innitialpos = transform.position;
        gaemhander =  GameObject.Find("Event controller");
        invent = GameObject.Find("Photo-inv");
        targetpos1 = GameObject.Find("filmhere").transform;
        cam = GameObject.Find("Event controller").GetComponent<Game_handler>().cam;
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

        if (mouseOnfilm)
        {
            transform.position = new Vector2(innitialpos.x, innitialpos.y);
            GameObject.Find("mechine").GetComponent<Mechine>().filmin = true;
            GameObject.Find("mechine").GetComponent<Mechine>().smolpic.GetComponent<SmoLpic>().pic = picturearray;
            GameObject.Find("mechine").GetComponent<Mechine>().smolpic.GetComponent<SmoLpic>().Smol = BlurArray;
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
        oninv = gaemhander.GetComponent<Game_handler>().mouseonINV;

        mouseOnfilm = false;
        raycast = Physics2D.RaycastAll(cam.ScreenToWorldPoint(Input.mousePosition), transform.forward);
        for (int i = raycast.Length - 1; i >= 0; i--)
        {
            if (raycast[i].collider.gameObject.CompareTag("Film"))
            {
                mouseOnfilm = true;
                break;
            }
        }
    }

    void setlayer(int layer)
    {
        transform.GetComponent<Picpart>().setlayer(layer);
    }

    void returelayer()
    {
        transform.GetComponent<Picpart>().returnlayer();
    }
}
