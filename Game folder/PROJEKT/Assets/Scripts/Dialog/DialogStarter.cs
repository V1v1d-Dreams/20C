using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogStarter : MonoBehaviour
{
    [SerializeField] GameObject Manager;
    [SerializeField] GameObject MucikPlayer;

    void Start()
    {
        Manager = GameObject.Find("GameProgressManager");
        MucikPlayer = GameObject.Find("MusicPlayer");

        StartCoroutine(Latestart(0.25f));
        MucikPlayer.GetComponent<Dailyplaylist>().statCoroteen();
        MucikPlayer.GetComponent<Dailyplaylist>().Loaded = false;

        IEnumerator Latestart(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            Manager.GetComponent<Progressmanager>().start();
        }
    }




}
