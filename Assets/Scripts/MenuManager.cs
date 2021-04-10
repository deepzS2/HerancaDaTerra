using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField]
    private GameObject _settingsMenu;

    [SerializeField]
    private GameObject _mainMenu;

    [SerializeField]
    private int _mainGameSceneIndex = 1;

    [Header("Settings vars")]
    [SerializeField]
    private AudioMixer _defaultMixer;

    [SerializeField]
    private Dropdown _resolutionDropdown;

    private float _newVolume;

    private Resolution _newResolution;

    private bool _newIsFullscreen;

    private Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;

        _resolutionDropdown.ClearOptions();

        int currentResolution = 0;
        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolution = i;
            }
        }

        _resolutionDropdown.AddOptions(options);
        _resolutionDropdown.value = currentResolution;
        _resolutionDropdown.RefreshShownValue();

        _mainMenu.SetActive(true);
        _settingsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Carrega as preferências anteriores ou novas do usuario
    /// </summary>
    void LoadPrefs()
    {
        float volume = PlayerPrefs.GetFloat("Volume");
        int resWidth = PlayerPrefs.GetInt("ResolutionWidth");
        int resHeight = PlayerPrefs.GetInt("ResolutionHeight");
        string isFullscreen = PlayerPrefs.GetString("Fullscreen");
        bool setFullscreen;

        if (isFullscreen == "True") setFullscreen = true;
        else setFullscreen = false;

        _defaultMixer.SetFloat("MainVolume", volume);
        Screen.SetResolution(resWidth, resHeight, setFullscreen);
    }

    /// <summary>
    /// Quando o botão de play for pressionado
    /// </summary>
    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene(_mainGameSceneIndex, LoadSceneMode.Single);
    }

    /// <summary>
    /// Quando o botão de settings for pressionado
    /// </summary>
    public void OnSettingsButtonPressed()
    {
        _settingsMenu.SetActive(true);
        _mainMenu.SetActive(false);
        return;
    }

    /// <summary>
    /// Quando o botão de exit for pressionado
    /// </summary>
    public void OnExitButtonPressed()
    {
        Application.Quit();
    }

    /// <summary>
    /// Set um volume no mixer default (pode-se ter vários para música, etc.)
    /// </summary>
    /// <param name="volume">Volume</param>
    public void setVolume(float volume)
    {
        _defaultMixer.SetFloat("MainVolume", volume);

        _newVolume = volume;
    }

    /// <summary>
    /// Fullscreen?
    /// </summary>
    /// <param name="isFullscreen"></param>
    public void setFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;

        _newIsFullscreen = isFullscreen;
    }
    
    /// <summary>
    /// Pega uma resolução e set ela
    /// </summary>
    /// <param name="resolutionIndex">Index do array de resolutions</param>
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        _newResolution = resolution;
    }

    /// <summary>
    /// Botão de cancelar do menu de opções
    /// </summary>
    public void OnCancelButtonPressed()
    {
        _settingsMenu.SetActive(false);
        _mainMenu.SetActive(true);

        LoadPrefs();
    }

    /// <summary>
    /// Botão de salvar alterações do menu de opções
    /// </summary>
    public void OnSaveChangesButtonPressed()
    {

        PlayerPrefs.SetFloat("Volume", _newVolume);
        PlayerPrefs.SetInt("ResolutionWidth", _newResolution.width);
        PlayerPrefs.SetInt("ResolutionHeight", _newResolution.height);
        PlayerPrefs.SetString("Fullscreen", _newIsFullscreen.ToString());
    }
}
