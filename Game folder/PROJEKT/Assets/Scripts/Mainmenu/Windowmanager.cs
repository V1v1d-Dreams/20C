using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class Windowmanager : MonoBehaviour
{
    [Header("Screen Options")]
    [Tooltip("Put dropdown in here")]
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    [Header("Object in scene")]
    [Tooltip("put button in here")]
    public GameObject playButton;
    //public GameObject continueButton;
    public GameObject settingButton;
    public GameObject setting;
    public GameObject confirmation;

    [Header("Scene")]
    [Range(0,10)]public int scene;

    void Start()
    {
        //confirmation.gameObject.SetActive(false);
        //setting.gameObject.SetActive(false);

        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i=0; i< resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }


    public void startGame()
    {
        closeAll();
        GameObject.Find("levelLoader").GetComponent<Levelloader>().loadLV(scene); //yeen's
        //SceneManager.LoadScene(scene);
    }

    public void continueGame()
    {
        //playButton.gameObject.SetActive(false);
        //continueButton.gameObject.SetActive(true);
        //optionButton.gameObject.SetActive(false);
    }

    public void settings()
    {
        closeAll();
        setting.gameObject.SetActive(true);
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void confirm()
    {
        closeAll();
        confirmation.gameObject.SetActive(true);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void notQuit()
    {
        confirmation.gameObject.SetActive(false);
    }
    public void closeAll()
    {
        setting.gameObject.SetActive(false);
        confirmation.gameObject.SetActive(false);
    }

}
