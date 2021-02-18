using UnityEngine;

public class Paper : MonoBehaviour
{
    public Texture2D Normal;
    public Texture2D Interactable;
    public Texture2D hold;

    public Vector2 innitialpos;
    private bool locked;

    [SerializeField] private Transform targetpos1;
    private Vector2 mouseposition;
    private float deltaX, deltaY;

    [SerializeField] private GameObject gaemhander;
    //[SerializeField] private GameObject invent;
    //bool oninv;

    [SerializeField] public bool isholding = false;
    [SerializeField] private float onhold = 0; //holdingpaper or not
    [SerializeField] public bool mouseOnPaper;
    [SerializeField] public GameObject Innitilpos;
    RaycastHit2D[] raycast;
    Camera cam;


    // Start is called before the first frame update
    void Start() 
    {
        Cursor.SetCursor(Normal, Vector2.zero, CursorMode.ForceSoftware);
        innitialpos = new Vector2(transform.position.x, transform.position.y);
        gaemhander = GameObject.Find("Event controller");
        //transform.SetParent(GameObject.Find("inventoryhitbox (0)").transform, true);

        cam = gaemhander.GetComponent<Game_handler>().cam;
        //invent = GameObject.Find("Photo-inv");
        targetpos1 = GameObject.Find("Paperhere").transform;
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
        /*setlayer(200);
        transform.SetParent(GameObject.Find("Bunch of pics").transform, true);
        Cursor.SetCursor(hold, Vector2.zero, CursorMode.ForceSoftware);
        if (!locked)
        {
            mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mouseposition.x - deltaX, mouseposition.y - deltaY);
        }*/
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
        //print("putdown");
        isholding = false;
        returelayer();
        Cursor.SetCursor(Normal, Vector2.zero, CursorMode.ForceSoftware);

        if (mouseOnPaper)
        {
            //transform.position = new Vector2(targetpos1.position.x, targetpos1.position.y);
            //innitialpos = transform.position;
            transform.position = new Vector2(innitialpos.x, innitialpos.y);
            GameObject.Find("mechine").GetComponent<Mechine>().paperin = true;
            //Destroy(gameObject);

        }
        /*
        else if (transform.position.x > 3.45 && transform.position.x < 7.83 && transform.position.y > -2.92 && transform.position.y < 2.94)
        {       
            //innitialpos = transform.position;
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

        FindObjectOfType<Navigator>().Enable("Paper", false);
        FindObjectOfType<Mechine>().holdingitem = false;

    }
    void Update()
    {
        innitialpos = Innitilpos.transform.position;
        //oninv = gaemhander.GetComponent<Game_handler>().mouseonINV;
        Hold();

        mouseOnPaper = false;
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
        transform.GetComponent<Picpart>().returnlayer();
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
                if (!FindObjectOfType<Mechine>().paperin)
                {
                    FindObjectOfType<Navigator>().Enable("Paper", true);
                    FindObjectOfType<Mechine>().holdingitem = true;
                }
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 0);
        }
    }
}
