using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
    public GameObject MainMenu;
    public GameObject OptionMenu;
    public GameObject PauseMenu;
    public GameObject Credits;
    public GameObject Credits_Options;
    public GameObject Controles;

    public Controller controller;

    void Start()
    {
        controller = new Controller();
        controller.Enable();
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i<resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        controller.MainController.Pause.performed += ctx => Escape();

    }


    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void Escape()
    {
        if (OptionMenu.activeSelf == true)
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                MainMenu.SetActive(true);
                OptionMenu.SetActive(false);
            }
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                OptionMenu.SetActive(false);
                PauseMenu.SetActive(true);
            }
        }

        else if (SceneManager.GetActiveScene().buildIndex == 1 && Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            PauseMenu.SetActive(true);
        }

        else if (SceneManager.GetActiveScene().buildIndex == 1 && PauseMenu.activeSelf == true)
        {
            Time.timeScale = 1f;
            PauseMenu.SetActive(false);
        }
        else if (Credits.activeSelf == true)
        {
            Credits.SetActive(false);
            MainMenu.SetActive(true);
        }
        else if (Credits_Options.activeSelf == true)
        {
            OptionMenu.SetActive(true);
            Credits_Options.SetActive(false);
        }
        else if ( Controles.activeSelf == true)
        {
            OptionMenu.SetActive(true);
            Controles.SetActive(false);
        }
    }
    public void ClosePause()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
    }
}
