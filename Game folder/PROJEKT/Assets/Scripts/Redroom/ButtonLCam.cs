using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLCam : MonoBehaviour
{
    GameObject eventcon;

    void Start()
    {
        eventcon = GameObject.Find("Event controller");
    }

    void OnMouseUp()
    {
        eventcon.GetComponent<Game_handler>().moveleft();
    }
}
