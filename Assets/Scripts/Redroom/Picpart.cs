using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picpart : MonoBehaviour
{
    public int orderinlayer;
    bool Done = false;


    void Start()
    {
        orderinlayer = this.GetComponent<SpriteRenderer>().sortingOrder;
    }

    public void setlayer(int layer)
    {
        if (!Done)
        {
            this.GetComponent<SpriteRenderer>().sortingOrder += layer;
            Done = true;
        }
    }

    public void returnlayer()
    {
        Done = false;
        this.GetComponent<SpriteRenderer>().sortingOrder = orderinlayer;
    }
}
