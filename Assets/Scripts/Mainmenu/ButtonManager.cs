using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]

public class ButtonManager : MonoBehaviour
{

    [Header("Screen Options")]
    [Tooltip("Put dropdown in here")]
    [SerializeField]
    Dropdown resolutionDropdown;
    Resolution[] resolutions;

    [Header("Animator")]
    [Tooltip("Every Animator here")]
    public Animator MainCamera;

    [Header("Scene to load")]
    [Range(0, 10)] public int PlayScene;

    List<int> widths = new List<int>() { 640, 800, 854, 1280, 1366, 1600, 1920, 2560, 3200, 3840 };
    List<int> heights = new List<int>() { 360, 450, 480, 720, 768, 900, 1080, 1440, 1800, 2160 };

    private void Awake()
    {
        dropDownCurrentStartResolution();
    }
    public void Start()
    {
        MainCamera.SetFloat("AnimationNumber", 0);

        //resolutionAll();
    }


    public void PlayButton()
    {
        MainCamera.SetInteger("AnimationNumber", -1);
        GameObject.Find("levelLoader").GetComponent<Levelloader>().loadLV(PlayScene);
    }
    public void Play_To_Main()
    {
        MainCamera.SetInteger("AnimationNumber", -1);
        GameObject.Find("levelLoader").GetComponent<Levelloader>().loadLV(0);
    }
    public void Settings()
    {
        MainCamera.SetInteger("AnimationNumber", 1);
    }
    public void Settings_To_Main()
    {
        MainCamera.SetInteger("AnimationNumber", 11);
    }
    public void Exit()
    {
        Application.Quit();
    }


    void resolutionAll()
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

    void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    void dropDownCurrentStartResolution()
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
    public void reworkSetResolution(int index)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, fullscreen);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}