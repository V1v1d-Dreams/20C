﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public enum Type { Tray, Hanger }

    public Type type;
    [SerializeField] public GameObject tray;
    [SerializeField] public GameObject icon;
    [SerializeField] double value;
    [SerializeField] int BarNumber;
    [SerializeField] float TimeWindow;
    [SerializeField] Animator BarAnim;
    [SerializeField] Sprite Warningsign;
    [SerializeField] Sprite click;

    void Start()
    {
        TimeWindow = GameObject.FindObjectOfType<Game_handler>().GetComponent<Game_handler>().PicTimeWindows + 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (tray.TryGetComponent(out Item_with_slot Slot))
        {
            if (Slot.Locked)
            {
                if (type == Type.Tray)
                {
                    BarAnim.SetBool("Icon", true);
                }
                //bar.GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<SpriteRenderer>().enabled = true;

                switch (BarNumber)
                {
                    case 1:
                        value = Slot.ObjectIN.GetComponent<Picture>().percent1;
                        break;
                    case 2:
                        value = Slot.ObjectIN.GetComponent<Picture>().percent2;
                        break;
                    case 3:
                        value = Slot.ObjectIN.GetComponent<Picture>().percent3;
                        break;
                    case 4:
                        value = Slot.ObjectIN.GetComponent<Picture>().percent4;
                        break;


                }

                if (value <= 130)
                {
                    icon.GetComponent<SpriteRenderer>().sprite = click;
                }
                else if (value > 130)
                {
                    icon.GetComponent<SpriteRenderer>().sprite = Warningsign;
                }
                if (type == Type.Tray)
                {
                    BarAnim.SetFloat("Value", (float)value);
                }
            }
            else
            {
                if (type == Type.Tray)
                {
                    BarAnim.SetBool("Icon", false);
                }
                GetComponent<SpriteRenderer>().enabled = false;
            }

            if (type == Type.Tray)
            {
                /*
                if (value > 100 && value < TimeWindow && GetComponent<SpriteRenderer>().color.g > 0)
                {
                    float temp = GetComponent<SpriteRenderer>().color.g - 0.002f;
                    GetComponent<SpriteRenderer>().color = new Color(1, temp, 0);
                }*/
                if (value > 150) //Value > timewindow
                {
                    //Destroy(Slot.ObjectIN);
                    Slot.ObjectIN.GetComponent<Picture>().Trash = true;
                }
                /*
                else if (value < 100)
                {
                    GetComponent<SpriteRenderer>().color = new Color(1, 0.739108f, 0);
                }
                */
            }
        }
    }
}
