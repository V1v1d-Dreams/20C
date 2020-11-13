using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_handler : MonoBehaviour
{
    [SerializeField] public Camera cam;
    private Vector3 cam_follow_pos;
    [SerializeField] private float moveAmount;
    [SerializeField] private float edgesize;
    [SerializeField] private Transform maxpos_X;
    [SerializeField] private Transform minpos_X;
    [SerializeField] GameObject film;
    [SerializeField] GameObject paper;
    [SerializeField] Transform filmpos;
    [SerializeField] Transform paperpos;
    [SerializeField] GameObject inv1;
    [SerializeField] GameObject inv2;
    [SerializeField] public bool placable = false;
    [SerializeField] Transform[] children;
    [SerializeField] public GameObject SoundManager;

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

    [Header("campos")]
    [SerializeField] public int[] CamPosittion;
    [SerializeField] public int CurrentCamPos = 1;

    RaycastHit2D[] raycast;
    RaycastHit2D[] Click;
    void Start()
    {
        cam_follow_pos = cam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Click = Physics2D.RaycastAll(cam.ScreenToWorldPoint(Input.mousePosition), transform.forward);
            print(Click[0].collider.gameObject.name);
            if (Click[0].collider.gameObject.CompareTag("Paper"))
            {
                Click[0].collider.gameObject.GetComponent<Paper>().isholding = true;
            }
            else if (Click[0].collider.gameObject.CompareTag("Photo"))
            {
                Click[0].collider.gameObject.GetComponent<Picture>().isholding = true;
            }
            else if (Click[0].collider.gameObject.CompareTag("FilmItem"))
            {
                Click[0].collider.gameObject.GetComponent<Film>().isholding = true;
            }
            else
            {
                if (Click[1].collider.gameObject.CompareTag("Photo"))
                {
                    Click[1].collider.gameObject.GetComponent<Picture>().isholding = true;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (Click[0].collider.gameObject.CompareTag("Paper"))
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

        timer();

        raycasting();
    
        //dynamicmovespeed();

        //movecam();

    }

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
            else if (raycast[i].collider.gameObject.CompareTag("ToolsINV"))
            {
                currentmouseon = raycast[i].collider.gameObject;
                if (!raycast[i].collider.gameObject.GetComponent<slotInv>().slotted)
                {
                    placable = true;
                }
                mouseontoolINV = true;
                break;
            }
            else if (raycast[i].collider.gameObject.CompareTag("Hanger"))
            {
                currentmouseon = raycast[i].collider.gameObject;

                if (!raycast[i].collider.gameObject.GetComponent<hanger>().Locked)
                {
                    placable = true;
                    break;
                }
            }
            else if (raycast[i].collider.gameObject.CompareTag("tray1"))
            {
                currentmouseon = raycast[i].collider.gameObject;
                mouseonTray1 = true;
                break;
            }
            else if (raycast[i].collider.gameObject.CompareTag("tray2"))
            {
                currentmouseon = raycast[i].collider.gameObject;
                mouseonTray2 = true;
                break;
            }
            else if (raycast[i].collider.gameObject.CompareTag("tray3"))
            {
                currentmouseon = raycast[i].collider.gameObject;
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
                    GameObject.Find("mechine").GetComponent<Mechine>().smolpic.GetComponent<SmoLpic>().pic = Click[0].collider.gameObject.GetComponent<Film>().picturearray;
                    GameObject.Find("mechine").GetComponent<Mechine>().smolpic.GetComponent<SmoLpic>().Smol = Click[0].collider.gameObject.GetComponent<Film>().BlurArray;
                    SoundManager.GetComponent<SoundManager>().PlayFX(1);
                }
                break;
            }
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

    public void RedRoomexit()
    {
        GameObject.Find("levelLoader").GetComponent<Levelloader>().loadLV(2);
        staticDataHolder.currentTime++;

        int children = GameObject.Find("Photo-inv").transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            if (GameObject.Find("Photo-inv").transform.GetChild(i).GetComponent<Picture>() == null)
            {

            }
            else
            {
                staticDataHolder.customerValue += GameObject.Find("Photo-inv").transform.GetChild(i).GetComponent<Picture>().Value;
            }
        }
        print(staticDataHolder.customerValue);

    }

}
