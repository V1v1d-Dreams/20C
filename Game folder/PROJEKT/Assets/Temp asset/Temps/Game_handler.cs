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
    [SerializeField] GameObject film;
    [SerializeField] GameObject paper;
    [SerializeField] Transform filmpos;
    [SerializeField] Transform paperpos;
    void Start()
    {
        cam_follow_pos = cam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
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
}
