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
    [SerializeField] GameObject Light;
    [SerializeField] GameObject ExitBTN;
    [SerializeField] GameObject ExitEnlarger;
    [SerializeField] GameObject Papernum;
    [SerializeField] GameObject paperX;
    
    void Awake()
    {

    }

    void Update()
    {
        CorrectPos = GameObject.Find("mechine").GetComponent<Mechine>().CanPress;
        double val = GameObject.Find("mechine").GetComponent<Mechine>().valuePercent;

        switch (GameObject.Find("mechine").GetComponent<Mechine>().MechineFilmIn)
        {
            case Replacer.FilmNumber.One:
                ChangeFilm(staticDataHolder.Todaysfilm.GetComponent<Film>());
                break;
            case Replacer.FilmNumber.Two:
                ChangeFilm(staticDataHolder.Todaysfilm2.GetComponent<Film>());
                break;
            case Replacer.FilmNumber.Three:
                ChangeFilm(staticDataHolder.Todaysfilm3.GetComponent<Film>());
                break;
        }

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

        if (CorrectPos)
        {
            Light.SetActive(true);
        }
        else
        {
            Light.SetActive(false);
        }

        if (CorrectPos && Press)
        {
            print("instantiate");
            Instantiate(pic[picnumber], spawnpt);

            GameObject.FindObjectOfType<RedroomNsoundmanager>().Picselect();

            staticDataHolder.papernumber -= 1;
            Overlay.SetActive(false);
            gameObject.SetActive(false);
            GameObject.Find("mechine").GetComponent<Mechine>().Opened = false;
            GameObject.Find("Event controller").GetComponent<Game_handler>().overlay = false;
            ExitBTN.SetActive(true);
            Papernum.SetActive(true);
            paperX.SetActive(true);

            if (!staticDataHolder.finishedtutorial)
            {
                FindObjectOfType<Game_handler>().PhotoProcessed = true;
                print("Processed");
            }

            //THis
            ExitEnlarger.SetActive(false);
            

        }
    }

    public void ChangeFilm(Film Infilm)
    {
        /*
        if (staticDataHolder.mechinelv == 1)
        {
            photopreview1.GetComponent<SpriteRenderer>().sprite = Infilm.FilmSprite;
        }
        else if (staticDataHolder.mechinelv == 2)
        {
            photopreview2.GetComponent<SpriteRenderer>().sprite = Infilm.FilmSprite;
        }
        else
        {
            photopreview3.GetComponent<SpriteRenderer>().sprite = Infilm.FilmSprite;
        }
        */
        pic = Infilm.picturearray;
    }
}
