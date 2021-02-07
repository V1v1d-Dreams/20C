using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmoLpic : MonoBehaviour
{
    //[SerializeField] public Sprite FilmSprite;
    [SerializeField] public GameObject[] pic;
    [SerializeField] Transform spawnpt;
    [SerializeField] GameObject Overlay;
    [SerializeField] public bool CorrectPos = false;
    [SerializeField] public bool Press = false;
    [SerializeField] int picnumber = 0;
    
    void Awake()
    {
        if (staticDataHolder.Todaysfilm.TryGetComponent(out Film Films))
        {
            gameObject.transform.Find("Photo preview").GetComponent<SpriteRenderer>().sprite = Films.FilmSprite;
            pic = Films.picturearray;
        }

    }

    void Update()
    {
        CorrectPos = GameObject.Find("mechine").GetComponent<Mechine>().CanPress;
        double val = GameObject.Find("mechine").GetComponent<Mechine>().valuePercent;

        if (val > 8.2 && val < 12.2)
        {
            picnumber = 0;
        }
        if (val > 27.5 && val < 31.5)
        {
            picnumber = 1;
        }
        if (val > 46.7 && val < 50.7)
        {
            picnumber = 2;
        }
        if (val > 66.3 && val < 70.3)
        {
            picnumber = 3;
        }
        if (val > 85.2 && val < 89.8)
        {
            picnumber = 4;
        }


        if (CorrectPos && Press)
        {
            print("instantiate");
            Instantiate(pic[picnumber], spawnpt);
            Overlay.SetActive(false);
            gameObject.SetActive(false);
            GameObject.Find("mechine").GetComponent<Mechine>().Opened = false;
            GameObject.Find("Event controller").GetComponent<Game_handler>().overlay = false;
        }
    }
}
