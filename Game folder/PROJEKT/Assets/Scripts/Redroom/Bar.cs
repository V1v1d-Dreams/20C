using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    [SerializeField] public GameObject tray;
    [SerializeField] public GameObject bar;
    [SerializeField] double value;
    [SerializeField] int BarNumber;


    // Update is called once per frame
    void Update()
    {
        if (tray.TryGetComponent(out Item_with_slot Slot))
        {
            if (Slot.Locked)
            {
                bar.GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<SpriteRenderer>().enabled = true;
                if (BarNumber == 1)
                {
                    value = Slot.ObjectIN.GetComponent<Picture>().percent1;
                }
                else if (BarNumber == 2)
                {
                    value = Slot.ObjectIN.GetComponent<Picture>().percent2;
                }
                else if (BarNumber == 3)
                {
                    value = Slot.ObjectIN.GetComponent<Picture>().percent3;
                }

                float scale;
                scale =  (float)(value/100 * 0.31);
                transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                bar.GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
