using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_handler : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private Vector3 cam_follow_pos;
    [SerializeField] private float moveAmount;
    [SerializeField] private float edgesize;
    [SerializeField] private Transform maxpos_X;
    [SerializeField] private Transform minpos_X;
    [SerializeField] public bool mouseonINV;
    [SerializeField] public bool mouseonfilmINV;
    [SerializeField] public bool mouseontoolINV;
    [SerializeField] GameObject film;
    [SerializeField] GameObject paper;
    [SerializeField] Transform filmpos;
    [SerializeField] Transform paperpos;
    [SerializeField] GameObject inv1;
    [SerializeField] GameObject inv2;
    [SerializeField] GameObject inv3;
    RaycastHit2D[] raycast;
    void Start()
    {
        cam_follow_pos = cam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        raycasting();
    
        dynamicmovespeed();

        movecam();

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
        mouseonfilmINV = false;
        mouseontoolINV = false;
        raycast = Physics2D.RaycastAll(cam.ScreenToWorldPoint(Input.mousePosition),transform.forward);
        for (int i = 0; i < raycast.Length; i++)
        {
            if (raycast[i].collider.gameObject.CompareTag("Inventory"))
            {
                mouseonINV = true;
                break;
            }
            else if (raycast[i].collider.gameObject.CompareTag("FilmINV"))
            {
                mouseonfilmINV = true;
                break;
            }
            else if (raycast[i].collider.gameObject.CompareTag("ToolsINV"))
            {
                mouseontoolINV = true;
                break;
            }
        }
    }
}
