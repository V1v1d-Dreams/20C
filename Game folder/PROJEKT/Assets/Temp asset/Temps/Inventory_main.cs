using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_main : MonoBehaviour
{
    [SerializeField] public GameObject gaemhander;

    void OnCollisionStay2D(Collision2D collision)
    {
        gaemhander.GetComponent<Game_handler>().mouseonINV = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gaemhander.GetComponent<Game_handler>().mouseonINV = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        gaemhander.GetComponent<Game_handler>().mouseonINV = false;
    }
}
