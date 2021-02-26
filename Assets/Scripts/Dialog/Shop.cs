using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [Header("Price")]
    public int Mechine1;
    public int Mechine2;
    public int Paper;
    public int Chem1;
    public int Chem2;
    public int Chem3;
    public int Tray;
    public int Hanger;

    public void Upgrade(string Name)
    {
        switch (Name)
        {
            case "Tray":
                staticDataHolder.tray = true;
                Debug.Log("Tray : " + staticDataHolder.tray);
                break;
            case "M1":
                staticDataHolder.mechinelv = 2;
                Debug.Log(staticDataHolder.mechinelv);
                break;
            case "M2":
                staticDataHolder.mechinelv = 3;
                Debug.Log(staticDataHolder.mechinelv);
                break;
            case "Paper":
                //WIP
                Debug.Log("Paper + 1");
                break;
            case "Chem1":
                staticDataHolder.chemlv = 1;
                Debug.Log(staticDataHolder.chemlv);
                break;
            case "Chem2":
                staticDataHolder.chemlv = 2;
                Debug.Log(staticDataHolder.chemlv);
                break;
            case "Chem3":
                staticDataHolder.chemlv = 3;
                Debug.Log(staticDataHolder.chemlv);
                break;
            case "Hanger":
                staticDataHolder.hangerLv +=1;
                Debug.Log(staticDataHolder.hangerLv);
                break;
}
    }


}
