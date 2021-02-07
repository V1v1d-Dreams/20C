using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechine : MonoBehaviour
{
    [SerializeField] GameObject MechineUI1;
    [SerializeField] GameObject MechineUI2;
    [SerializeField] GameObject MechineUI3;
    public bool Opened = false;
    [SerializeField] public GameObject gaemhander;
    [SerializeField] public bool filmin = false;
    [SerializeField] public bool paperin = false;
    [SerializeField] public bool ButtonP = false;
    [SerializeField] public GameObject PhotoPreView;
    [SerializeField] public float value;
    [Range(0f,100f)]
    [SerializeField] public float valuePercent;
    [SerializeField] public bool CanPress;
    [SerializeField] public float delayed = 10;



    void Start()
    {

    }

    void Update()
    {
        //print(delayed);
        
        if(delayed > 0 && Opened)
        {
            delayed -= Time.deltaTime;
        }

        value = ((valuePercent / 100) * 5.7f) - 2.7f; //FIX THIS
        if (filmin&&paperin&&!Opened&&ButtonP)
        {
            //smolpic.GetComponent<SmoLpic>().nextclicktime = Time.time + smolpic.GetComponent<SmoLpic>().timer;
            StartCoroutine(Randomize());

            if (gaemhander.GetComponent<Game_handler>().Magnifier_Lv == 1)
            {
                MechineUI1.SetActive(true);
                PhotoPreView = GameObject.Find("Photo preview");
            }
            else if (gaemhander.GetComponent<Game_handler>().Magnifier_Lv == 2)
            {
                MechineUI2.SetActive(true);
                PhotoPreView = GameObject.Find("Photo preview2");
            }
            else
            {
                MechineUI3.SetActive(true);
                PhotoPreView = GameObject.Find("Photo preview3");
            }

            Opened = true;
            paperin = false;
            gaemhander.GetComponent<Game_handler>().overlay = true;
        }

        PhotoPreView.transform.localPosition = new Vector3(PhotoPreView.transform.localPosition.x, value, 0);

        if ((valuePercent > 8.2 && valuePercent < 12.2)|| (valuePercent > 27.5 && valuePercent < 31.5)|| (valuePercent > 46.7 && valuePercent < 50.7)|| (valuePercent > 66.3 && valuePercent < 70.3)|| (valuePercent > 85.2 && valuePercent < 89.8))
        {
            CanPress = true;
        }
        else
        {
            CanPress = false;
        }

    }

    IEnumerator Randomize()
    {
        valuePercent = Random.Range(0f, 100f);
        yield break;
    }
}
