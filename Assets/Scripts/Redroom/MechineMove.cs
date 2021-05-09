using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechineMove : MonoBehaviour
{
    GameObject mechine;
    Camera cam;
    RaycastHit2D[] raycast;
    [SerializeField] int picnum = 0;

    void Start()
    {
        mechine = GameObject.Find("mechine");
        cam = GameObject.Find("Event controller").GetComponent<Game_handler>().cam;

    }

    void Update()
    {
        this.GetComponent<SmoLpic>().Press = false;

        raycast = Physics2D.RaycastAll(cam.ScreenToWorldPoint(Input.mousePosition), transform.forward);
        foreach (RaycastHit2D hit in raycast)
        {
            if (Input.GetMouseButton(0)&& mechine.GetComponent<Mechine>().valuePercent >= 0 && mechine.GetComponent<Mechine>().valuePercent <= 100)
            {
                if (hit.collider.transform.gameObject.name == "Down Arrow")
                {
                    mechine.GetComponent<Mechine>().valuePercent -= 0.1f;

                    GameObject.FindObjectOfType<RedroomNsoundmanager>().Scroll12();
                }
                else if (hit.collider.transform.gameObject.name == "Up arrow")
                {
                    mechine.GetComponent<Mechine>().valuePercent += 0.1f;

                    GameObject.FindObjectOfType<RedroomNsoundmanager>().Scroll12();
                }
            }

            else if (hit.collider.transform.gameObject.name == "FinishButton" && Input.GetMouseButtonUp(0) && mechine.GetComponent<Mechine>().delayed <= 0)
            {
                this.GetComponent<SmoLpic>().Press = true;
                print("Press");
            }

            else if (hit.collider.transform.gameObject.name == "Up arrow2" && Input.GetMouseButtonUp(0))
            {
                mechine.GetComponent<Mechine>().valuePercent += 5f;

                GameObject.FindObjectOfType<RedroomNsoundmanager>().Scroll12();

                float val = mechine.GetComponent<Mechine>().valuePercent;
                if (val > 8.2 && val < 12.2)
                {
                    val = 10.2f;
                }
                else if (val > 27.5 && val < 31.5)
                {
                    val = 29.5f;
                }
                else if (val > 46.7 && val < 50.7)
                {
                    val = 48.7f;
                }
                else if (val > 66.3 && val < 70.3)
                {
                    val = 68.3f;
                }
                else if (val > 85.2 && val < 89.2)
                {
                    val = 87.2f;
                }
                mechine.GetComponent<Mechine>().valuePercent = val;

            }
            else if (hit.collider.transform.gameObject.name == "Down Arrow2" && Input.GetMouseButtonUp(0))
            {
                mechine.GetComponent<Mechine>().valuePercent -= 5f;

                GameObject.FindObjectOfType<RedroomNsoundmanager>().Scroll12();

                float val = mechine.GetComponent<Mechine>().valuePercent;
                if (val > 8.2 && val < 12.2)
                {
                    val = 10.2f;
                }
                else if (val > 27.5 && val < 31.5)
                {
                    val = 29.5f;
                }
                else if (val > 46.7 && val < 50.7)
                {
                    val = 48.7f;
                }
                else if (val > 66.3 && val < 70.3)
                {
                    val = 68.3f;
                }
                else if (val > 85.2 && val < 89.2)
                {
                    val = 87.2f;
                }
                mechine.GetComponent<Mechine>().valuePercent = val;
            }
            else if (hit.collider.transform.gameObject.name == "Down Arrow3" && Input.GetMouseButtonUp(0))
            {

                GameObject.FindObjectOfType<RedroomNsoundmanager>().Scroll3();
                float val = mechine.GetComponent<Mechine>().valuePercent;
                if ( val >= 0f && val < 10.2f)
                {
                    val = 10.2f;
                }
                else if (val >= 10.2f && val < 29.5f)
                {
                    val = 29.5f;
                }
                else if (val >= 29.5f && val < 48.7f)
                {
                    val = 48.7f;
                }
                else if (val >= 48.7f && val < 68.3f)
                {
                    val = 68.3f;
                }
                else if (val >= 68.3f && val < 87.2f)
                {
                    val = 87.2f;
                }
                mechine.GetComponent<Mechine>().valuePercent = val;
            }
            else if (hit.collider.transform.gameObject.name == "Up arrow3" && Input.GetMouseButtonUp(0))
            {

                GameObject.FindObjectOfType<RedroomNsoundmanager>().Scroll3();
                float val = mechine.GetComponent<Mechine>().valuePercent;
                if (val <= 100f && val > 87.2f)
                {
                    val = 87.2f;
                }
                else if (val <= 87.2f && val > 68.3f)
                {
                    val = 68.3f;
                }
                else if (val <= 68.3f && val > 48.7f)
                {
                    val = 48.7f;
                }
                else if (val <= 48.7f && val > 29.5f)
                {
                    val = 29.5f;
                }
                else if (val <= 29.5f && val > 10.2f)
                {
                    val = 10.2f;
                }
                mechine.GetComponent<Mechine>().valuePercent = val;
            }
        }

        if (mechine.GetComponent<Mechine>().valuePercent <= 0)
        {
            mechine.GetComponent<Mechine>().valuePercent = 0;
        }

        if (mechine.GetComponent<Mechine>().valuePercent >= 100)
        {
            mechine.GetComponent<Mechine>().valuePercent = 100;
        }

    }
}
