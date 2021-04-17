using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhotoinfilmCheck : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI Text1;
    [SerializeField] TMPro.TextMeshProUGUI Text2;
    [SerializeField] TMPro.TextMeshProUGUI Text3;
    [SerializeField] GameObject photoinv;
    [SerializeField] List<Transform> Piclist;
    [SerializeField] Transform[] countingArray;

    private int Picinfilm1;
    private int Picinfilm2;
    private int Picinfilm3;



    void Start()
    {
        Picinfilm1 = staticDataHolder.Todaysfilm.GetComponent<Film>().PicInFilm1;

        if (staticDataHolder.Todaysfilm2 == null)
        {

        }
        else
        {
            Picinfilm2 = staticDataHolder.Todaysfilm.GetComponent<Film>().PicInFilm2;
        }

        if (staticDataHolder.Todaysfilm3 == null)
        {

        }
        else
        {
            Picinfilm3 = staticDataHolder.Todaysfilm.GetComponent<Film>().PicInFilm3;
        }


        if (Picinfilm1 == 0)
        {
            Text1.gameObject.SetActive(false);
        }
        if (Picinfilm2 == 0)
        {
            Text2.gameObject.SetActive(false);
        }
        if (Picinfilm3 == 0)
        {
            Text3.gameObject.SetActive(false);
        }

        Checkphoto();
    }

    public void Checkphoto()
    {
        countingArray = new Transform[0];
        Piclist = new List<Transform>();

        foreach (Transform GameOBJ in photoinv.transform)
        {
            if (GameOBJ.gameObject.TryGetComponent(out Picture Pic))
            {
                if (Pic.PhotoID != 0)
                {
                    Piclist.Add(GameOBJ);
                }
            }
        }
        countingArray = Piclist.ToArray();

        for (int j = 0; j < countingArray.Length; j++)
        {
            for (int k = 0; k < countingArray.Length; k++)
            {
                if (j != k)
                {
                    if (countingArray[j].gameObject.GetComponent<Picture>().PhotoID == countingArray[k].gameObject.GetComponent<Picture>().PhotoID)
                    {
                        if (countingArray[j].gameObject.GetComponent<Picture>().value > countingArray[k].gameObject.GetComponent<Picture>().value)
                        {
                            countingArray[k].gameObject.GetComponent<Picture>().value = 0;
                        }
                        else
                        {
                            countingArray[j].gameObject.GetComponent<Picture>().value = 0;
                        }
                    }
                }
            }
        }
        int film1 = 0;
        int film2 = 0;
        int film3 = 0;

        for (int j = 0; j < countingArray.Length; j++)
        {
            if ((countingArray[j].gameObject.GetComponent<Picture>().value != 0) && (countingArray[j].gameObject.GetComponent<Picture>().PhotoInFilm == 1))
            {
                print("found1");
                film1 += 1;
            }
            else if ((countingArray[j].gameObject.GetComponent<Picture>().value != 0) && (countingArray[j].gameObject.GetComponent<Picture>().PhotoInFilm == 2))
            {
                film2 += 1;
            }
            else if ((countingArray[j].gameObject.GetComponent<Picture>().value != 0) && (countingArray[j].gameObject.GetComponent<Picture>().PhotoInFilm == 3))
            {
                film3 += 1;
            }

        }


        Text1.text = "film 1 - photo : " + film1 + "/" + Picinfilm1;
        Text2.text = "film 2 - photo : " + film2 + "/" + Picinfilm2;
        Text3.text = "film 3 - photo : " + film3 + "/" + Picinfilm3;

    }
}
