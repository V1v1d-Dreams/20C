using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replacer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Film>().picturearray = staticDataHolder.Todaysfilm.GetComponent<Film>().picturearray;
        GetComponent<Film>().BlurArray = staticDataHolder.Todaysfilm.GetComponent<Film>().BlurArray;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
