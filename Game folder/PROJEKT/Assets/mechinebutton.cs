using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechinebutton : MonoBehaviour
{
    public GameObject mechine;
    public float delay;

    // Update is called once per frame
    void Update()
    {
        
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
