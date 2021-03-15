using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [Header("Price")]
    [SerializeField] public int Mechine1;
    [SerializeField] public int Mechine2;
    [SerializeField] public int Paper;
    [SerializeField] public int Chem1;
    [SerializeField] public int Chem2;
    [SerializeField] public int Chem3;
    [SerializeField] public int Tray;
    [SerializeField] public int Hanger;

    [Header("Sold")]
    [SerializeField] public Sprite SoldChem1;
    [SerializeField] public Sprite SoldChem2;
    [SerializeField] public Sprite SoldChem3;
    [SerializeField] public Sprite SoldEnlarger1;
    [SerializeField] public Sprite SoldEnlarger2;
    [SerializeField] public Sprite SoldTray;
    [SerializeField] public Sprite SoldHanger;

    [Header("SoldLebel")]
    [SerializeField] public GameObject SoldChemLebel1;
    [SerializeField] public GameObject SoldChemLebel2;
    [SerializeField] public GameObject SoldChemLebel3;
    [SerializeField] public GameObject SoldEnlargerLebel1;
    [SerializeField] public GameObject SoldEnlargerLebel2;
    [SerializeField] public GameObject SoldTrayLebel;
    [SerializeField] public GameObject SoldHangerLebel;

    [Header("Normal")]
    [SerializeField] public Sprite NormalChem1;
    [SerializeField] public Sprite NormalChem2;
    [SerializeField] public Sprite NormalChem3;
    [SerializeField] public Sprite NormalEnlarger1;
    [SerializeField] public Sprite NormalEnlarger2;
    [SerializeField] public Sprite NormalTray;
    [SerializeField] public Sprite NormalHanger;

    [Header("Button")]
    [SerializeField] public Button ChemBTN1;
    [SerializeField] public Button ChemBTN2;
    [SerializeField] public Button ChemBTN3;
    [SerializeField] public Button EnlargerBTN1;
    [SerializeField] public Button EnlargerBTN2;
    [SerializeField] public Button TrayBTN;
    [SerializeField] public Button HangerBTN;

    void Start()
    {
        switch (staticDataHolder.chemlv) //WIP
        {
            case 1:
                //ChemBTN1.image = SoldChem1;
                //ChemBTN2.image = NormalChem2;
                //ChemBTN3.image = NormalChem2;
                break;
            case 2:
                //ChemBTN1.targetGraphic.GetComponent<Image>().sprite = NormalChem1;
                //ChemBTN2.targetGraphic.GetComponent<Image>().sprite = SoldChem2;
                //ChemBTN3.targetGraphic.GetComponent<Image>().sprite = NormalChem2;
                break;
            case 3:
                //ChemBTN1.targetGraphic.GetComponent<Image>().sprite = NormalChem1;
                //ChemBTN2.targetGraphic.GetComponent<Image>().sprite = NormalChem2;
                //ChemBTN3.targetGraphic.GetComponent<Image>().sprite = SoldChem3;
                break;
        }

        switch (staticDataHolder.tray)
        {
            case true:
                TrayBTN.targetGraphic.GetComponent<Image>().sprite = SoldTray;
                TrayBTN.enabled = false;
                SoldTrayLebel.SetActive(true);
                break;
            case false:
                //Do something?
                break;
        }

        switch (staticDataHolder.mechinelv)
        {
            case 1:
                //Something
                break;
            case 2:
                EnlargerBTN1.targetGraphic.GetComponent<Image>().sprite = SoldEnlarger1;
                EnlargerBTN1.enabled = false;
                SoldEnlargerLebel1.SetActive(true);
                break;
            case 3:
                EnlargerBTN1.targetGraphic.GetComponent<Image>().sprite = SoldEnlarger1;
                EnlargerBTN1.enabled = false;
                SoldEnlargerLebel1.SetActive(true);
                EnlargerBTN2.targetGraphic.GetComponent<Image>().sprite = SoldEnlarger2;
                EnlargerBTN2.enabled = false;
                SoldEnlargerLebel2.SetActive(true);
                break;
        }

        switch (staticDataHolder.hangerLv)
        {
            case 1:
                //something
                break;
            case 2:
                //Something
                break;
            case 3:
                HangerBTN.targetGraphic.GetComponent<Image>().sprite = SoldHanger;
                HangerBTN.enabled = false;
                SoldHangerLebel.SetActive(true);
                break;
            default:
                HangerBTN.targetGraphic.GetComponent<Image>().sprite = SoldHanger;
                HangerBTN.enabled = false;
                SoldHangerLebel.SetActive(true);
                break;
        }

    }




    public void Upgrade(string Name)
    {
        switch (Name)
        {
            case "Tray":
                if (staticDataHolder.money - Tray >= 0)
                {
                    staticDataHolder.money -= Tray;
                    staticDataHolder.tray = true;
                    TrayBTN.targetGraphic.GetComponent<Image>().sprite = SoldTray;
                    TrayBTN.enabled = false;
                    SoldTrayLebel.SetActive(true);
                    //Debug.Log("Tray : " + staticDataHolder.tray);
                    //Debug.Log(staticDataHolder.money);
                    break;
                }
                else
                {
                    //Do something
                    //Debug.Log(staticDataHolder.money);
                    break;
                }

            case "M1":
                if (staticDataHolder.money - Mechine1 >= 0)
                {
                    staticDataHolder.money -= Mechine1;
                    staticDataHolder.mechinelv = 2;
                    EnlargerBTN1.targetGraphic.GetComponent<Image>().sprite = SoldEnlarger1;
                    EnlargerBTN1.enabled = false;
                    SoldEnlargerLebel1.SetActive(true);
                    //Debug.Log(staticDataHolder.mechinelv);
                    //Debug.Log(staticDataHolder.money);
                    break;
                }
                else
                {
                    //Do something
                    //Debug.Log(staticDataHolder.money);
                    break;
                }
            case "M2":
                if (staticDataHolder.money - Mechine2 >= 0)
                {
                    staticDataHolder.money -= Mechine2;
                    staticDataHolder.mechinelv = 3;
                    EnlargerBTN1.targetGraphic.GetComponent<Image>().sprite = SoldEnlarger1;
                    EnlargerBTN1.enabled = false;
                    SoldEnlargerLebel1.SetActive(true);
                    EnlargerBTN2.targetGraphic.GetComponent<Image>().sprite = SoldEnlarger2;
                    EnlargerBTN2.enabled = false;
                    SoldEnlargerLebel2.SetActive(true);
                    //Debug.Log(staticDataHolder.mechinelv);
                    //Debug.Log(staticDataHolder.money);
                    break;
                }
                else
                {
                    //Do something
                    //Debug.Log(staticDataHolder.money);
                    break;
                }
            case "Paper":
                if (staticDataHolder.money - Paper >= 0)
                {
                    staticDataHolder.money -= Paper;
                    staticDataHolder.papernumber += 5;
                    //Debug.Log(staticDataHolder.money);
                    break;
                }
                else
                {
                    //Do something
                    //Debug.Log(staticDataHolder.money);
                    break;
                }
                //----------------------------------------------------------------
            case "Chem1":
                if (staticDataHolder.money - Chem1 >= 0)
                {
                    staticDataHolder.money -= Chem1;
                    ChemBTN1.targetGraphic.GetComponent<Image>().sprite = SoldChem1;
                    ChemBTN2.targetGraphic.GetComponent<Image>().sprite = SoldChem2;
                    ChemBTN3.targetGraphic.GetComponent<Image>().sprite = SoldChem3;
                    ChemBTN1.enabled = false;
                    ChemBTN2.enabled = false;
                    ChemBTN3.enabled = false;
                    SoldChemLebel1.SetActive(true);
                    SoldChemLebel2.SetActive(true);
                    SoldChemLebel3.SetActive(true);
                    //------------------------------------------
                    staticDataHolder.chemlv = 1;
                    //Debug.Log(staticDataHolder.chemlv);
                    //Debug.Log(staticDataHolder.money);
                    break;
                }
                else
                {
                    //Do something
                    //Debug.Log(staticDataHolder.money);
                    break;
                }
                //----------------------------------------------------------------
            case "Chem2":
                if (staticDataHolder.money - Chem2 >= 0)
                {
                    staticDataHolder.money -= Chem2;
                    ChemBTN1.targetGraphic.GetComponent<Image>().sprite = SoldChem1;
                    ChemBTN2.targetGraphic.GetComponent<Image>().sprite = SoldChem2;
                    ChemBTN3.targetGraphic.GetComponent<Image>().sprite = SoldChem3;
                    ChemBTN1.enabled = false;
                    ChemBTN2.enabled = false;
                    ChemBTN3.enabled = false;
                    SoldChemLebel1.SetActive(true);
                    SoldChemLebel2.SetActive(true);
                    SoldChemLebel3.SetActive(true);
                    //------------------------------------------
                    staticDataHolder.chemlv = 2;
                    //Debug.Log(staticDataHolder.chemlv);
                    //Debug.Log(staticDataHolder.money);
                    break;
                }
                else
                {
                    //Do something
                    //Debug.Log(staticDataHolder.money);
                    break;
                }
                //----------------------------------------------------------------
            case "Chem3":
                if (staticDataHolder.money - Chem3 >= 0)
                {
                    staticDataHolder.money -= Chem3;
                    ChemBTN1.targetGraphic.GetComponent<Image>().sprite = SoldChem1;
                    ChemBTN2.targetGraphic.GetComponent<Image>().sprite = SoldChem2;
                    ChemBTN3.targetGraphic.GetComponent<Image>().sprite = SoldChem3;
                    ChemBTN1.enabled = false;
                    ChemBTN2.enabled = false;
                    ChemBTN3.enabled = false;
                    SoldChemLebel1.SetActive(true);
                    SoldChemLebel2.SetActive(true);
                    SoldChemLebel3.SetActive(true);
                    //------------------------------------------
                    staticDataHolder.chemlv = 3;
                    //Debug.Log(staticDataHolder.chemlv);
                    //Debug.Log(staticDataHolder.money);
                    break;
                }
                else
                {
                    //Do something
                    //Debug.Log(staticDataHolder.money);
                    break;
                }
                //----------------------------------------------------------------
            case "Hanger":
                if (staticDataHolder.money - Hanger >= 0)
                {
                    staticDataHolder.money -= Hanger;
                    staticDataHolder.hangerLv += 1;
                    if (staticDataHolder.hangerLv >= 3)
                    {
                        HangerBTN.targetGraphic.GetComponent<Image>().sprite = SoldHanger;
                        HangerBTN.enabled = false;
                        SoldHangerLebel.SetActive(true);
                    }
                    //Debug.Log(staticDataHolder.hangerLv);
                    //Debug.Log(staticDataHolder.money);
                    break;
                }
                else
                {
                    //Do something
                    //Debug.Log(staticDataHolder.money);
                    break;
                }

        }
    }


}
