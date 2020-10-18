using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextField : MonoBehaviour
{
    [TextArea(2, 3)]
    [SerializeField] string[] Dialog;
    char[] Chararray;
    [SerializeField] Transform Textstart;
    [SerializeField] Transform textlocation;
    [SerializeField] GameObject Char;
    [SerializeField] int i = 0;
    [SerializeField] GameObject[] CharsObj;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            textlocation.position = new Vector3(Textstart.position.x , Textstart.position.y,textlocation.position.z);
            if (i < Dialog.Length)
            {
                this.GetComponent<Textmanager>().NewtextPos = 0;

                //find all letter and for loop delete
                CharsObj = GameObject.FindGameObjectsWithTag("letter");
                for (int A = 0; A < CharsObj.Length; A++)
                {
                    Destroy(CharsObj[A]);
                }

                Chararray = Dialog[i].ToCharArray();
                for (int iNdex = 0; iNdex < Chararray.Length; iNdex++)
                {
                    textlocation.position = new Vector3(this.GetComponent<Textmanager>().DisplayDialog(Chararray[iNdex], textlocation, Char), textlocation.position.y, textlocation.position.z);
                }
                i++;
            }
        }
    }

}
