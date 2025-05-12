using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManagement : MonoBehaviour
{
    [Header("Menus")]
     public string newGameScene;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject options;

    [Header("Áudio")]
    public Slider volumeSlider;
    public AudioSource volumeAudio;

    [Header("Tela")]
    public Toggle fullScreenToggle;
    public TMP_Dropdown resolutionDropdown;

    private Resolution[] availableResolutions;

    void Start()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);

        LoadResolutions();
        LoadInitialSettings();
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(newGameScene);
    }

    public void OpenOptions()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
    }

    public void CloseOptions()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void LoadResolutions()
    {
        resolutionDropdown.ClearOptions();
        availableResolutions = Screen.resolutions;

        int savedResolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", -1);
        int currentResolutionIndex = 0;

        resolutionDropdown.options.Clear();

        for (int i = 0; i < availableResolutions.Length; i++)
        {
            string option = availableResolutions[i].width + " x " + availableResolutions[i].height;
            resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(option));

            if (availableResolutions[i].width == Screen.width &&
                availableResolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        int finalIndex = (savedResolutionIndex >= 0 && savedResolutionIndex < availableResolutions.Length) 
                        ? savedResolutionIndex 
                        : currentResolutionIndex;

        resolutionDropdown.value = finalIndex;
        resolutionDropdown.RefreshShownValue();
        ChangeResolution(finalIndex);
    }

    private void LoadInitialSettings()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");
            AudioListener.volume = volumeSlider.value;
        }
        else
        {
            volumeSlider.value = 1f;
        }

        if (PlayerPrefs.HasKey("Fullscreen"))
        {
            bool isFullscreen = PlayerPrefs.GetInt("Fullscreen") == 1;
            Screen.fullScreen = isFullscreen;
            fullScreenToggle.isOn = isFullscreen;
        }
        else
        {
            Screen.fullScreen = true;
            fullScreenToggle.isOn = true;
        }

        resolutionDropdown.RefreshShownValue();
    }

    public void ChangeResolution(int selectedIndex)
    {
        if (selectedIndex >= 0 && selectedIndex < availableResolutions.Length)
        {
            Resolution res = availableResolutions[selectedIndex];
            Screen.SetResolution(res.width, res.height, Screen.fullScreen);
            PlayerPrefs.SetInt("ResolutionIndex", selectedIndex);
            PlayerPrefs.Save();
        }
    }

    public void SetFullscreen()
    {
        Screen.fullScreen = fullScreenToggle.isOn;
        PlayerPrefs.SetInt("Fullscreen", fullScreenToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void VolumeController()
    {
        AudioListener.volume = volumeSlider.value;

        if (volumeAudio != null)
        {
            volumeAudio.volume = volumeSlider.value;
        }

        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        PlayerPrefs.Save();
    }
}
