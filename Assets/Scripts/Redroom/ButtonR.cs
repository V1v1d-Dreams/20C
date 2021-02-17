using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonR : MonoBehaviour
{
    GameObject smolpic;

    void Start()
    {
        smolpic = GameObject.Find("ImageSmol");
    }

    void OnMouseUp()
    {
        //smolpic.GetComponent<SmoLpic>().goright();
    }
}
