using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class CheckFilm : MonoBehaviour
{
    [SerializeField] GameObject mechine;
    // Start is called before the first frame update
    void Start()
    {
        mechine = GameObject.Find("mechine");
    }

    // Update is called once per frame
    void Update()
    {
        switch (FindObjectOfType<Game_handler>().Magnifier_Lv)
        {
            case 1:
                transform.localPosition = new Vector3(0.004f, 0.233f,0f);
                break;
            case 2:
                transform.localPosition = new Vector3(0.004f, 0.2916f,0f);
                break;
            case 3:
                transform.localPosition = new Vector3(0.004f, 0.2916f, 0f);
                break;
        }


        if (!mechine.GetComponent<Mechine>().filmin)
        {
            UnityEngine.Experimental.Rendering.Universal.Light2D m_light = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
            m_light.enabled = false;
        }
        else
        {
            UnityEngine.Experimental.Rendering.Universal.Light2D m_light = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
            m_light.enabled = true;
        }
    }
}
