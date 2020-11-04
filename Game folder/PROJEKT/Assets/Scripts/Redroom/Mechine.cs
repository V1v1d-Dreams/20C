using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechine : MonoBehaviour
{
    [SerializeField] GameObject smolpic;
    [SerializeField] GameObject buttonR;
    [SerializeField] GameObject buttonL;
    [SerializeField] GameObject overlay;
    [SerializeField] GameObject camleft;
    [SerializeField] GameObject camright;
    public bool Opened = false;
    [SerializeField] public GameObject gaemhander;
    [SerializeField] public bool filmin = false;
    [SerializeField] public bool paperin = false;
    [SerializeField] public bool ButtonP = false;



    void Start()
    {
    }

    void Update()
    {
        if (filmin&&paperin&&!Opened&&ButtonP)
        {
            smolpic.SetActive(true);
            overlay.SetActive(true);
            buttonR.SetActive(true);
            buttonL.SetActive(true);
            camleft.SetActive(false);
            camright.SetActive(false);
            Opened = true;
        }
    }
}
