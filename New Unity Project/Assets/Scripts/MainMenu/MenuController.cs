using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{

    [Header("Levels to load")]
    [SerializeField] private GameObject noSavedGameDialogue = null;
    public string newGameLoad;
    private string levelToLoad;

    [Header("Confirmation Prompt")]
    [SerializeField] private GameObject confirmationPrompt = null;

    [Header("Volume setting")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 0.5f;

    [Header("Gameplay Settings")]
    [SerializeField] private TMP_Text controllerSensitivityValue = null;
    [SerializeField] private Slider controllerSensitivitySlider = null;
    [SerializeField] private float defaultSensitivity = 0.5f;
    public float mainControllerSensitivity = 0.5f;

    [Header("Toggle Settings")]
    [SerializeField] private Toggle invertYToggle = null;

    [Header("Graphic Settings")]
    [SerializeField] private Slider brightnessSlider = null;
    [SerializeField] private TMP_Text brightnessTextValue = null;
    [SerializeField] private float defaultBrightness = 1f;

    [Space(10)]
    [SerializeField] private TMP_Dropdown qualityDropdown;
    [SerializeField] private Toggle fullScreenToggle;

    private int qualityLvl;
    private bool isFullscreen;
    private float brightnessLvl;

    [Header("Resolution dropdowns")]
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;


    public void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = 1;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void NewGameDialogueYes()
    {
        SceneManager.LoadScene(newGameLoad);
    }

    public void LoadGameDialogueYes()
    {
        if (PlayerPrefs.HasKey("SavedGame"))
        {
            levelToLoad = PlayerPrefs.GetString("SavedGame");
            SceneManager.LoadScene(levelToLoad);
        }

        else
        {
            noSavedGameDialogue.SetActive(true);
        }
    }


    public void QuitGameButton()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }

   

    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(1);
        confirmationPrompt.SetActive(false);
    }

    public void SerControllerSensitivity(float sensitivity)
    {
        mainControllerSensitivity = sensitivity;
        controllerSensitivityValue.text = sensitivity.ToString("0.0");
    }

    public void GameplayApply()
    {
        if (invertYToggle.isOn)
        {
            PlayerPrefs.SetFloat("masterInvertY", 1);
        }

        else
        {
            PlayerPrefs.SetFloat("masterInvertY", 0);
        }

        PlayerPrefs.SetFloat("masterSensitivity", mainControllerSensitivity);
        StartCoroutine(ConfirmationBox());
    }

    public void SetBrightness(float brightness)
    {
        brightnessLvl = brightness;
        brightnessTextValue.text = brightness.ToString("0.0");
    }
    
    public void SetFullscreen(bool fulllscreen)
    {
        isFullscreen = fulllscreen;
    }

    public void SetQuality(int qualityIndex)
    {
        qualityLvl = qualityIndex;
    }

    public void GraphicsApply()
    {
        PlayerPrefs.SetFloat("masterBrightness", brightnessLvl);
        PlayerPrefs.SetInt("masterQuality", qualityLvl);
        QualitySettings.SetQualityLevel(qualityLvl);
        PlayerPrefs.SetInt("masterFullscreen", (isFullscreen ? 1 : 0));
        Screen.fullScreen = isFullscreen;
        StartCoroutine(ConfirmationBox());
    }

    public void ResetButton(string menuType)
    {
        if(menuType == "Graphics")
        {
            brightnessSlider.value = defaultBrightness;
            brightnessTextValue.text = defaultBrightness.ToString("0.0");
            qualityDropdown.value = 1;
            QualitySettings.SetQualityLevel(1);

            fullScreenToggle.isOn = false;
            Screen.fullScreen = false;

            Resolution currentResolution = Screen.currentResolution;
            Screen.SetResolution(currentResolution.width, currentResolution.height, Screen.fullScreen);
            resolutionDropdown.value = resolutions.Length;
            GraphicsApply();
        }

        if (menuType == "Sound")
        {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volumeTextValue.text = defaultVolume.ToString("0.0");
            VolumeApply();
        }

        if (menuType == "Gameplay")
        {
            controllerSensitivityValue.text = defaultSensitivity.ToString("0.0");
            controllerSensitivitySlider.value = defaultSensitivity;
            mainControllerSensitivity = defaultSensitivity;
            invertYToggle.isOn = false;
            GameplayApply();
        }
    }
}

