using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public enum Type { Tray, Hanger }

    public Type type;
    [SerializeField] public GameObject tray;
    [SerializeField] public GameObject bar;
    [SerializeField] double value;
    [SerializeField] int BarNumber;
    [SerializeField] float TimeWindow;

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
                bar.GetComponent<SpriteRenderer>().enabled = true;
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

                float scale;
                if (value <= 100)
                {
                    scale = (float)(value / 100 * 0.31);
                    transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
                }
            }
            else
            {
                bar.GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
            }

            if (type == Type.Tray)
            {
                if (value > 100 && value < TimeWindow && GetComponent<SpriteRenderer>().color.g > 0)
                {
                    float temp = GetComponent<SpriteRenderer>().color.g - 0.002f;
                    GetComponent<SpriteRenderer>().color = new Color(1, temp, 0);
                }
                else if (value > TimeWindow)
                {
                    //Destroy(Slot.ObjectIN);
                    Slot.ObjectIN.GetComponent<Picture>().Trash = true;
                }
                else if (value < 100)
                {
                    GetComponent<SpriteRenderer>().color = new Color(1, 0.739108f, 0);
                }
            }
        }
    }
}
