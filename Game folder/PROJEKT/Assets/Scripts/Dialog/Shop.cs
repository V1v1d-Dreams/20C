using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] Sprite mechinelv1;
    [SerializeField] Sprite mechinelv2;
    [SerializeField] Sprite mechinelv3;
    [SerializeField] string text1;
    [SerializeField] string text2;
    [SerializeField] string text3;
    [SerializeField] Text TextUI1;
    [SerializeField] Image Image1;
    [SerializeField] int mechinelv;
    [SerializeField] int price1;
    [SerializeField] int price2;




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
            
    }

    public void upgradeLv()
    {
        if (mechinelv<3)
        {
            staticDataHolder.mechinelv += 1;
        }
    }
}
