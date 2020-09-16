using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picpart : MonoBehaviour
{
    public int orderinlayer;


    void Start()
    {
        orderinlayer = this.GetComponent<SpriteRenderer>().sortingOrder;
    }

    public void setlayer(int layer)
    {
        this.GetComponent<SpriteRenderer>().sortingOrder = layer;
    }

    public void returnlayer()
    {
        this.GetComponent<SpriteRenderer>().sortingOrder = orderinlayer;
    }
}
