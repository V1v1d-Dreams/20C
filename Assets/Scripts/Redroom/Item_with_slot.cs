using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_with_slot : MonoBehaviour
{
    public enum Type { Tray, Hanger };
    [SerializeField] public Type type = Type.Tray;
    [SerializeField] public bool Locked = false;
    [SerializeField] public GameObject ObjectIN;

    private void Update()
    {
        if (ObjectIN != null)
        {
            if (ObjectIN.TryGetComponent(out Picture pic))
            {
                if (pic.isholding == true)
                {
                    Locked = false;
                    ObjectIN = null;
                }
            }

            if (type == Type.Hanger)
            {
                GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else
        {
            Locked = false;
            if (type == Type.Hanger)
            {
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }


    }
}
