using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Windowmanager : MonoBehaviour
{
    Resolution[] resolutions;
    public Dropdown resolutionDropdown;

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        
        for (int i=0; i< resolutions.Length; i++)
        {
            //(resolutions[i].width + "X" + resolutions[i].height).Add(resolutions[i].width + "X" + resolutions[i].height);
        }

        resolutionDropdown.AddOptions(options);
    }
}
