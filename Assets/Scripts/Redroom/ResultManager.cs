﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    [SerializeField] List<Transform> Piclist;
    [SerializeField] Transform[] countingArray;
    [SerializeField] Animator anim;
    [SerializeField] GameObject photoinv; 
    [SerializeField] GameObject ResultOverlay;
    [SerializeField] TMPro.TextMeshProUGUI Good;
    [SerializeField] TMPro.TextMeshProUGUI Ok;
    [SerializeField] TMPro.TextMeshProUGUI Bad;
    [SerializeField] TMPro.TextMeshProUGUI Result;
    [SerializeField] TMPro.TextMeshProUGUI MoneyEarned;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RedRoomexit()
    {
        if (staticDataHolder.finishedtutorial)
        {
            GameObject.Find("exit_Button").SetActive(false);
            GameObject.Find("paperNum").SetActive(false);
            GameObject.Find("paperNum_x").SetActive(false);


            double result = 0; //TOTAL %-------------------------------------------------------------------------------------------------------------------
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

            int good = 0;
            int bad = 0;
            int ok = 0;

            for (int j = 0; j < countingArray.Length; j++)
            {
                result += countingArray[j].gameObject.GetComponent<Picture>().value;
                if ((countingArray[j].gameObject.GetComponent<Picture>().value != 0) && (countingArray[j].gameObject.GetComponent<Picture>().value < 60))
                {
                    bad += 1;
                }
                else if ((countingArray[j].gameObject.GetComponent<Picture>().value >= 60) && (countingArray[j].gameObject.GetComponent<Picture>().value < 80))
                {
                    ok += 1;
                }
                else if (countingArray[j].gameObject.GetComponent<Picture>().value >= 80)
                {
                    good += 1;
                }

            }

            Good.text = good.ToString();
            Bad.text = bad.ToString();
            Ok.text = ok.ToString();



            result = result / GameObject.Find("Film (1)").GetComponent<Film>().Picnumber;

            //Debug.Log(result);
            int Moneyearn = 0;

            if (result < 60)
            {
                Result.text = "BAD";
                Moneyearn = 0;
                staticDataHolder.money += 0;
                staticDataHolder.customerValue = 1;
            }
            else if (result >= 60 && result < 74)
            {
                Result.text = "OK";
                Moneyearn = staticDataHolder.lumpsum;
                staticDataHolder.money += staticDataHolder.lumpsum;
            }
            else if (result >= 74 && result < 85)
            {
                Result.text = "GOOD";
                Moneyearn = (staticDataHolder.lumpsum / 4) + staticDataHolder.lumpsum;
                staticDataHolder.money += (staticDataHolder.lumpsum / 4) + staticDataHolder.lumpsum;
            }
            else if (result >= 85)
            {
                Result.text = "GREAT";
                Moneyearn = (staticDataHolder.lumpsum / 2) + staticDataHolder.lumpsum;
                staticDataHolder.money += (staticDataHolder.lumpsum / 2) + staticDataHolder.lumpsum;
            }

            print("lumpsum : "+ staticDataHolder.lumpsum);

            MoneyEarned.text = "$" + Moneyearn.ToString();

            staticDataHolder.money += staticDataHolder.lumpsum;

            //MoneyEarned.text = "$" + ((ok * 10) + (good * 20)).ToString();
            //staticDataHolder.money += (ok * 10) + (good * 20);

            ResultOverlay.SetActive(true);

            anim.SetTrigger("GOOOO");

            staticDataHolder.Todaysfilm = null;
            staticDataHolder.Todaysfilm2 = null;
            staticDataHolder.Todaysfilm3= null;

            //pause & play on this

            GameObject.Find("levelLoader").GetComponent<Levelloader>().DelayedLoad(2, 10); //EXIT DELAY, CHANGE SECOND VALUE
            staticDataHolder.currentTime++;
        }
        else
        {
            //pause & play on this

            GameObject.Find("levelLoader").GetComponent<Levelloader>().DelayedLoad(2, 0);
            staticDataHolder.currentTime++;
        }
        
    }
}
