using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool GameIsPause = false;  //*****IMPORTANT! PLEASE STATE THIS IN EVERY ACTIONS OF OTHER SCRIPT*****
    //public GameObject ingameCursor;
    [Header("Canvas")]
    public GameObject pauseMenuUI;
    public GameObject menuPause;
    public GameObject Setting;
    public GameObject ReturnConfirmation;
    //public GameObject ForSceneChanger;
   
    [Header("Sound")]
    public AudioSource SFXSource;
    public AudioSource BGMSource;
    public AudioClip onHover;
    public AudioClip onClick;
    public AudioClip onPause;
   
    [Header("Scene")]
    [Range(0, 10)] public int menu;

    GameObject player;
    //bool IsGamePaused = false;
    void Start()
    {
        Time.timeScale = 1.0f;
        //ingameCursor = GameObject.Find("cursor");
        pauseMenuUI.SetActive(false);
        Setting.SetActive(false);
        ReturnConfirmation.SetActive(false);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

                if (GameIsPause == true)
                {
                    mainPauseMenu();

                    Resume();
                }
                else
                {
                    Pause();
                }

        }
    }

    public void mainPauseMenu()
    {
        menuPause.gameObject.SetActive(true);
        Setting.gameObject.SetActive(false);
        ReturnConfirmation.gameObject.SetActive(false);
    }
    public void options()
    {
        menuPause.gameObject.SetActive(false);
        Setting.gameObject.SetActive(true);
        ReturnConfirmation.gameObject.SetActive(false);
    }
    public void Returntomenu()
    {
        menuPause.gameObject.SetActive(false);
        Setting.gameObject.SetActive(false);
        ReturnConfirmation.gameObject.SetActive(true);
    }
    public void Resume()
    {
        BGMSource.UnPause();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        //ingameCursor.gameObject.SetActive(true);
    }
    void Pause()
    {
        BGMSource.Pause();
        SFXSource.PlayOneShot(onPause);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        //print(Time.timeScale);
        //IsGamePaused = true;
        GameIsPause = true;
        //Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //ingameCursor.gameObject.SetActive(false);
    }
    public void hover()
    {
        SFXSource.PlayOneShot(onHover);
    }
    public void click()
    {
        SFXSource.PlayOneShot(onClick);
    }

    public void menuLoad()
    {
        SceneManager.LoadScene(menu);
    }
}
