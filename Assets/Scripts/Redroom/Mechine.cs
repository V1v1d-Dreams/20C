using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechine : MonoBehaviour
{
    public Replacer.FilmNumber MechineFilmIn;

    [SerializeField] GameObject MechineUI1;
    [SerializeField] GameObject MechineUI2;
    [SerializeField] GameObject MechineUI3;
    [SerializeField] Sprite mechinelv1;
    [SerializeField] Sprite mechinelv2;
    [SerializeField] Sprite mechinelv3;
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
    [HideInInspector] public bool holdingitem = false;

    [SerializeField] GameObject EnlargerExit;
    [SerializeField] GameObject RedRoomExit;



    void Start()
    {

    }

    void Update()
    {
        if (!filmin && !holdingitem)
        {
            FindObjectOfType<Navigator>().Enable("Getfilm", true);
        }
        else
        {
            FindObjectOfType<Navigator>().Enable("Getfilm", false);
        }

        if (!paperin && !holdingitem)
        {
            FindObjectOfType<Navigator>().Enable("Getpaper", true);
        }
        else
        {
            FindObjectOfType<Navigator>().Enable("Getpaper", false);
        }

        if (gaemhander.GetComponent<Game_handler>().Magnifier_Lv == 1)
        {
            GetComponent<SpriteRenderer>().sprite = mechinelv1;
        }
        else if (gaemhander.GetComponent<Game_handler>().Magnifier_Lv == 2)
        {
            GetComponent<SpriteRenderer>().sprite = mechinelv2;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = mechinelv3;
        }

        if (delayed > 0 && Opened)
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
                GetComponent<SpriteRenderer>().sprite = mechinelv1;
                MechineUI1.SetActive(true);
                PhotoPreView = GameObject.Find("Photo preview");
            }
            else if (gaemhander.GetComponent<Game_handler>().Magnifier_Lv == 2)
            {
                GetComponent<SpriteRenderer>().sprite = mechinelv2;
                MechineUI2.SetActive(true);
                PhotoPreView = GameObject.Find("Photo preview2");
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = mechinelv3;
                MechineUI3.SetActive(true);
                PhotoPreView = GameObject.Find("Photo preview3");
            }

            EnlargerExit.SetActive(true);
            RedRoomExit.SetActive(false);


            Opened = true;
            paperin = false;
            gaemhander.GetComponent<Game_handler>().overlay = true;
            //THIS
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
        while ((valuePercent > 8.2 && valuePercent < 12.2)|| (valuePercent > 27.5 && valuePercent < 31.5) || (valuePercent > 46.7 && valuePercent < 50.7) || (valuePercent > 66.3 && valuePercent < 70.3) || (valuePercent > 85.2 && valuePercent < 89.8))
        {
            valuePercent = Random.Range(0f, 100f);
        }
        yield break;
    }

    public void ExitEnlarger()
    {

        if (gaemhander.GetComponent<Game_handler>().Magnifier_Lv == 1)
        {
            GetComponent<SpriteRenderer>().sprite = mechinelv1;
            MechineUI1.SetActive(false);
            PhotoPreView = GameObject.Find("Photo preview");
        }
        else if (gaemhander.GetComponent<Game_handler>().Magnifier_Lv == 2)
        {
            GetComponent<SpriteRenderer>().sprite = mechinelv2;
            MechineUI2.SetActive(false);
            PhotoPreView = GameObject.Find("Photo preview2");
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = mechinelv3;
            MechineUI3.SetActive(false);
            PhotoPreView = GameObject.Find("Photo preview3");
        }

        EnlargerExit.SetActive(false);
        RedRoomExit.SetActive(true);


        Opened = false;
        paperin = true;
        gaemhander.GetComponent<Game_handler>().overlay = false;
    }
}
