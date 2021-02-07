using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

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
        //print("check");
    }

    IEnumerator loadlevel(int levelindex)
    {
        Time.timeScale = 1;

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

    public void Day1()
    {
        StartCoroutine(loadlevel(2));
        staticDataHolder.currentTime = 0;
        staticDataHolder.currentIndex = 0;
    }

    public void Day2()
    {
        StartCoroutine(loadlevel(2));
        staticDataHolder.currentTime = 0;
        staticDataHolder.currentIndex = 2;
    }
    public void Day3()
    {
        StartCoroutine(loadlevel(2));
        staticDataHolder.currentTime = 0;
        staticDataHolder.currentIndex = 4;
    }
    public void Day4()
    {
        StartCoroutine(loadlevel(2));
        staticDataHolder.currentTime = 0;
        staticDataHolder.currentIndex = 6;
    }
    public void Day5()
    {
        StartCoroutine(loadlevel(2));
        staticDataHolder.currentTime = 0;
        staticDataHolder.currentIndex = 8;
    }
    public void Day6()
    {
        StartCoroutine(loadlevel(2));
        staticDataHolder.currentTime = 0;
        staticDataHolder.currentIndex = 10;
    }

    public void Day1EVEN()
    {
        StartCoroutine(loadlevel(2));
        staticDataHolder.currentTime = 0;
        staticDataHolder.currentIndex = 1;
    }

    public void Day2EVEN()
    {
        StartCoroutine(loadlevel(2));
        staticDataHolder.currentTime = 0;
        staticDataHolder.currentIndex = 3;
    }
    public void Day3EVEN()
    {
        StartCoroutine(loadlevel(2));
        staticDataHolder.currentTime = 0;
        staticDataHolder.currentIndex = 5;
    }
    public void Day4EVEN()
    {
        StartCoroutine(loadlevel(2));
        staticDataHolder.currentTime = 0;
        staticDataHolder.currentIndex = 7;
    }
    public void Day5EVEN()
    {
        StartCoroutine(loadlevel(2));
        staticDataHolder.currentTime = 0;
        staticDataHolder.currentIndex = 9;
    }
    public void Day6EVEN()
    {
        StartCoroutine(loadlevel(2));
        staticDataHolder.currentTime = 0;
        staticDataHolder.currentIndex = 11;
    }

    public void LoadGame(int slot)
    {

        if (System.IO.File.Exists(Application.persistentDataPath +"/Savedata_" + slot + ".json"))
        {
            string jsonstring = File.ReadAllText(Application.persistentDataPath + "/Savedata_" + slot + ".json");
            SaveData save = JsonUtility.FromJson<SaveData>(jsonstring);
            staticDataHolder.Save_ = save;
            Debug.Log("load " + "Savedata_" + slot);
            loadLV(2);
        }
        else
        {
            SaveData save = new SaveData(0,1,0,slot);
            staticDataHolder.Save_ = save;
            save.SaveIntoJson(save);
            Debug.Log("create " + "Savedata_" + slot);
            loadLV(2);
        }
    }


}
