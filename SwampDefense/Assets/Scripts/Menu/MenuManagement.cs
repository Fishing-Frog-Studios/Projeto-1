using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio; 

public class MenuManagement : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject options;
    public Slider volumeSlider;
    public AudioSource volumeAudio;


    void Start()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
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

    public void SetResolution()
    {
        
    }

    public void SetFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void VolumeController()
    {
        AudioListener.volume = Mathf.Log10(AudioListener.volume) * 20;
        AudioListener.volume = volumeSlider.value;
    }
}

