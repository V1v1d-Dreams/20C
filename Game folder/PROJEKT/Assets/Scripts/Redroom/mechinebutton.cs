using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechinebutton : MonoBehaviour
{
    public GameObject mechine;
    public float delay;
    GameObject light;

    void Start()
    {
        light = GameObject.Find("greenlight");
    }
    // Update is called once per frame
    void Update()
    {
        if (mechine.GetComponent<Mechine>().filmin && mechine.GetComponent<Mechine>().paperin && !mechine.GetComponent<Mechine>().Opened)
        {
            this.GetComponent<SpriteRenderer>().color = Color.green;
            light.SetActive(true);
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
            light.SetActive(false);
        }
    }

    void OnMouseUp()
    {
        StartCoroutine(Buttonpress());
    }


    IEnumerator Buttonpress()
    {
        mechine.GetComponent<Mechine>().ButtonP = true;

        yield return new WaitForSeconds(delay);

        mechine.GetComponent<Mechine>().ButtonP = false;


    }
}
