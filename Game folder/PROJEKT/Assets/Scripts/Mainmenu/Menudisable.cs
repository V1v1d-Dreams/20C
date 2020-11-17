using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menudisable : MonoBehaviour
{

    [SerializeField] GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            canvas.SetActive(false);
        }
        else
        {
            canvas.SetActive(true);
        }    
    }
}
