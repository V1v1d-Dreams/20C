using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelloader : MonoBehaviour
{
    public Animator transition;
    public float transitiontime;

    void Update()
    {
        
    }

    public void loadnextLV()
    {
        StartCoroutine(loadlevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void loadLV(int lv)
    {
        StartCoroutine(loadlevel(lv));
    }

    IEnumerator loadlevel(int levelindex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitiontime);

        SceneManager.LoadScene(levelindex);


    }    

    public void newday()
    {
        StartCoroutine(loadlevel(2));
        staticDataHolder.currentTime = 0;
    }

    public void Done()
    {
        StartCoroutine(loadlevel(1));
        staticDataHolder.currentTime = 0;
        staticDataHolder.currentIndex = 0;
    }
}
