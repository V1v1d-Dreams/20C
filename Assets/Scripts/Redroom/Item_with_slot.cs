using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_with_slot : MonoBehaviour
{
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
        }
        else
        {
            Locked = false;
        }

    }
}
