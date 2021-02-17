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
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    [Header("Animator")]
    [Tooltip("Every Animator here")]
    public Animator MainCamera;

    [Header("Scene to load")]
    [Range(0, 10)] public int PlayScene;

    public void Start()
    {
        MainCamera.SetFloat("AnimationNumber", 0);

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




    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}