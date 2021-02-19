using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [Header("Mechine")]
    [SerializeField] Sprite mechinelv1;
    [SerializeField] Sprite mechinelv2;
    [SerializeField] Sprite mechinelv3;
    [SerializeField] string text1;
    [SerializeField] string text2;
    [SerializeField] string text3;
    [SerializeField] Text TextUI1;
    [SerializeField] Image Image1;
    [SerializeField] int mechinelv;
    [SerializeField] int mechine_price1;
    [SerializeField] int mechine_price2;

    [Header("Hanger")]
    [SerializeField] Sprite hangerlv1;
    [SerializeField] Sprite hangerlv2;
    [SerializeField] Sprite hangerlv3;
    [SerializeField] string text4;
    [SerializeField] string text5;
    [SerializeField] string text6;
    [SerializeField] Text TextUI2;
    [SerializeField] Image Image2;
    [SerializeField] int HangerLv;
    [SerializeField] int Hanger_price1;
    [SerializeField] int Hanger_price2;




    void Start()
    {
        mechinelv = staticDataHolder.mechinelv;
        TextUI1.text = text1;
    }

    // Update is called once per frame
    void Update()
    {
        mechinelv = staticDataHolder.mechinelv;
        switch (mechinelv)
        {

            case 1:
                TextUI1.text = text1;
                Image1.sprite = mechinelv1;
                break;

            case 2:
                TextUI1.text = text2;
                Image1.sprite = mechinelv2;
                break;

            case 3:
                TextUI1.text = text3;
                Image1.sprite = mechinelv3;
                break;


        }

        HangerLv = staticDataHolder.hangerLv;
        switch (HangerLv)
        {

            case 1:
                TextUI2.text = text4;
                Image2.sprite = hangerlv1;
                break;

            case 2:
                TextUI2.text = text5;
                Image2.sprite = hangerlv2;
                break;

            case 3:
                TextUI2.text = text6;
                Image2.sprite = hangerlv3;
                break;


        }

    }

    public void upgradeLv()
    {
        if (mechinelv<3)
        {
            staticDataHolder.mechinelv += 1;
        }
    }

    public void UpgradeLvHanger()
    {
        if (HangerLv < 3)
        {
            staticDataHolder.hangerLv += 1;
        }
    }
}
