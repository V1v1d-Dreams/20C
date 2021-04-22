using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseScript : MonoBehaviour
{
    [Tooltip("GameIsPauseBool, Update ")]
    public static bool GameIsPause = false;  //*****IMPORTANT! PLEASE STATE THIS IN EVERY ACTIONS OF OTHER SCRIPT*****
    //public GameObject ingameCursor;
    [Header("Canvas")]
    public GameObject pauseMenuUI;
    public GameObject settingMenuUI;
    public GameObject menuPause;
    public GameObject ReturnConfirmation;
    public GameObject background;
    //public GameObject ForSceneChanger;
   
    [Header("Sound")]
    public AudioSource SFXSource;
    public AudioSource BGMSource;
    public AudioClip onHover;
    public AudioClip onClick;
    public AudioClip onPause;
   
    [Header("Scene")]
    [Range(0, 10)] public int menu;

    [Header("GameObject")]
    public GameObject RayTraceBlocker;
    public GameObject Debugger;
    [System.NonSerialized] bool DebugActive = false;

    GameObject player;
    //bool IsGamePaused = false;

    [SerializeField] TMP_Dropdown TMPResolutionDropdown;
    Resolution[] resolutions;
    List<int> widths = new List<int>() { 640, 800, 854, 1280, 1366, 1600, 1920, 2560, 3200, 3840 };
    List<int> heights = new List<int>() { 360, 450, 480, 720, 768, 900, 1080, 1440, 1800, 2160 };

    private void Awake()
    {
        
    }
    void Start()
    {
        Time.timeScale = 1.0f;
        //ingameCursor = GameObject.Find("cursor");
        pauseMenuUI.SetActive(false);
        settingMenuUI.SetActive(false);
        ReturnConfirmation.SetActive(false);
        background.SetActive(false);
        TMPDropDownCurrentStartResolution();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

                if (GameIsPause == true)
                {
                    mainPauseMenu();

                    Resume();

                    RayTraceBlocker.SetActive(false);
                }
                else
                {
                    Pause();

                    RayTraceBlocker.SetActive(true);
                }

            
        }

        if (Input.GetKeyUp(KeyCode.F12))
        {
            DebugActive = !DebugActive; 
            Debugger.SetActive(DebugActive);

        }


    }

    public void mainPauseMenu()
    {
        background.SetActive(true);
        menuPause.gameObject.SetActive(true);
        settingMenuUI.gameObject.SetActive(false);
        ReturnConfirmation.gameObject.SetActive(false);
    }
    public void options()
    {
        menuPause.gameObject.SetActive(false);
        settingMenuUI.gameObject.SetActive(true);
        ReturnConfirmation.gameObject.SetActive(false);
        background.SetActive(false);
    }
    public void Returntomenu()
    {
        menuPause.gameObject.SetActive(false);
        settingMenuUI.gameObject.SetActive(false);
        ReturnConfirmation.gameObject.SetActive(true);
    }
    public void Resume()
    {
        background.SetActive(false);
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
        background.SetActive(true);
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
        GameObject.Find("levelLoader").GetComponent<Levelloader>().loadLV(menu);
        //SceneManager.LoadScene(menu);
    }

    void TMPDropDownCurrentStartResolution()
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
                            TMPResolutionDropdown.value = x;
                            return;
                        }
                        return;
                    }
                }
            }
        }
    }


}
