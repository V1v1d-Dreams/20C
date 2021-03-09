using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Film : MonoBehaviour
{
    public Replacer.FilmNumber FilmFilmnum;

    [SerializeField] public int Picnumber;
    [SerializeField] public Sprite FilmSprite;

    public Texture2D Normal;
    public Texture2D Interactable;
    public Texture2D hold;

    public Vector2 innitialpos;
    private bool locked;

    //[SerializeField] private Transform targetpos1;
    private Vector2 mouseposition;
    private float deltaX, deltaY;

    [SerializeField] public GameObject[] picturearray;
    [SerializeField] public Sprite[] BlurArray;

    [SerializeField] public bool mouseOnfilm;

    [SerializeField] public bool isholding = false;
    //[SerializeField] GameObject invSlot;
    [SerializeField] GameObject Filmslot;
    [SerializeField] private float onhold = 0; //holdingflim or not

    // Start is called before the first frame update
    void Start() 
    {
        Cursor.SetCursor(Normal, Vector2.zero, CursorMode.ForceSoftware);
        innitialpos = transform.position;
        //targetpos1 = GameObject.Find("filmhere").transform;
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
        isholding = false;

        returelayer();
        Cursor.SetCursor(Normal, Vector2.zero, CursorMode.ForceSoftware);

        if (mouseOnfilm)
        {
            transform.position = new Vector2(innitialpos.x, innitialpos.y);
            GameObject.Find("mechine").GetComponent<Mechine>().filmin = true;
            GameObject.Find("mechine").GetComponent<Mechine>().MechineFilmIn = FilmFilmnum;
            //GameObject.Find("mechine").GetComponent<Mechine>().smolpic.GetComponent<SmoLpic>().pic = picturearray;
            //GameObject.Find("mechine").GetComponent<Mechine>().smolpic.GetComponent<SmoLpic>().Smol = BlurArray;
        }/*
        else if (transform.position.x > 3.45 && transform.position.x < 7.83 && transform.position.y > -2.92 && transform.position.y < 2.94)
        {       
            innitialpos = transform.position;
        }
        else if (oninv)
        {
            setlayer(101);
            transform.SetParent(invent.transform, true);
        }*/
        else
        {
            transform.position = new Vector2(innitialpos.x, innitialpos.y);
        }

        FindObjectOfType<Navigator>().Enable("Mechine", false);
        FindObjectOfType<Mechine>().holdingitem = false;
    }
    void Update()
    {
        Hold();

        innitialpos = Filmslot.transform.position;

        //oninv = gaemhander.GetComponent<Game_handler>().mouseonINV;

        mouseOnfilm = false;
    }

    void setlayer(int layer)
    {
        if (onhold == 0)
        {
            GetComponent<Picpart>().setlayer(layer);
            transform.GetComponent<SpriteRenderer>().sortingLayerName = "OnHold";
            onhold = 1;
        }
    }

    void returelayer()
    {
        transform.GetComponent<Picpart>().returnlayer();
        transform.GetComponent<SpriteRenderer>().sortingLayerName = "Dafault";
        onhold = 0;
    }

    void Hold()
    {
        if (isholding)
        {
            Cursor.SetCursor(hold, Vector2.zero, CursorMode.ForceSoftware);
            if (!locked)
            {
                setlayer(200);
                //transform.SetParent(GameObject.Find("Bunch of pics").transform, true);
                mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector2(mouseposition.x - deltaX, mouseposition.y - deltaY);
                GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                if (!FindObjectOfType<Mechine>().filmin)
                {
                    FindObjectOfType<Mechine>().holdingitem = true;
                    FindObjectOfType<Navigator>().Enable("Mechine", true);
                }
            }
        }
        else
        {
            //GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 0);
        }
    }
}
