using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogStarter : MonoBehaviour
{
    [SerializeField] GameObject Manager;

    void Start()
    {
        Manager = GameObject.Find("GameProgressManager");

        StartCoroutine(Latestart(0.25f));
    }

    IEnumerator Latestart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Manager.GetComponent<Progressmanager>().start();
    }

}
