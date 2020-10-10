using System.Collections;
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


    // Start is called before the first frame update
    void Start() 
    {
        Cursor.SetCursor(Normal, Vector2.zero, CursorMode.ForceSoftware);
        innitialpos = transform.position;
        gaemhander =  GameObject.Find("Event controller");
        invent = GameObject.Find("Film-inv");
        targetpos1 = GameObject.Find("filmhere").transform;
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
            innitialpos = transform.position;
            GameObject.Find("mechine").GetComponent<Mechine>().filmin = true;
            Destroy(gameObject);

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
        oninv = gaemhander.GetComponent<Game_handler>().mouseonfilmINV;

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
