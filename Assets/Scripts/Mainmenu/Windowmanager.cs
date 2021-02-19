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

    List<int> widths = new List<int>() { 640, 800, 854, 1280, 1366, 1600, 1920, 2560, 3200, 3840 };
    List<int> heights = new List<int>() { 360, 450, 480, 720, 768, 900, 1080, 1440, 1800, 2160 };

    void Awake()
    {
        currentResolution();
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
    void resolutionsetting()
    {
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
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
    void currentResolution()
    {
        for (int x = 0; x < widths.Count; x++)
        {
            if (Screen.width == widths[x])
            {
                for (int y = 0; y < heights.Count; y++)
                {
                    if (Screen.height == heights[y])
                    {
                        if (x == y)
                        {
                            resolutionDropdown.value = x;
                            return;
                        }
                        return;
                    }
                }
            }
        }
    }
    public void reworkResolution(int index)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, fullscreen);
    }
}
