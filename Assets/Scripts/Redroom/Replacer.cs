using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replacer : MonoBehaviour
{
    public enum FilmNumber { One, Two, Three}
    public FilmNumber filmnum;


    // Start is called before the first frame update
    void Awake()
    {
        if (filmnum == Replacer.FilmNumber.One)
        {
            if (staticDataHolder.Todaysfilm.TryGetComponent(out Film films))
            {
                GetComponent<Film>().picturearray = films.picturearray;
                GetComponent<Film>().FilmFilmnum = filmnum;
                GetComponent<Film>().Picnumber = films.Picnumber;
            }
        }
        else if (filmnum == Replacer.FilmNumber.Two)
        {
            if (staticDataHolder.Todaysfilm2.TryGetComponent(out Film films))
            {
                GetComponent<Film>().picturearray = films.picturearray;
                GetComponent<Film>().FilmFilmnum = filmnum;
            }
        }
        else if (filmnum == Replacer.FilmNumber.Three)
        {
            if (staticDataHolder.Todaysfilm3.TryGetComponent(out Film films))
            {
                GetComponent<Film>().picturearray = films.picturearray;
                GetComponent<Film>().FilmFilmnum = filmnum;
            }
        }



        //GetComponent<Film>().picturearray = staticDataHolder.Todaysfilm.GetComponent<Film>().picturearray;
        //GetComponent<Film>().BlurArray = staticDataHolder.Todaysfilm.GetComponent<Film>().BlurArray;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
