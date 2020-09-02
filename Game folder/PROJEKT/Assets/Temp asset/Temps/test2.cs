using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour
{
    float ver1 = 3.71f;
    public Animator sss;
    bool S = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            S = true;
        }
       
        if (S && ver1 > -3.6f)
        {
            ver1 -= 0.05f;
        }

        if (ver1 < 1.54)
        {
            sss.SetTrigger("process");
        }



        transform.position = new Vector3(transform.position.x, ver1, transform.position.z);
    }
}
