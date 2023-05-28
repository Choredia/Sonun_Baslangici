using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DSettingsMenu1 : MonoBehaviour
{
    public Text volumeAmount;
    public Slider slider;

    private void Start()
    {
        InitializeAudio();
    }

    public void SetAudio(float value)
    {
        float normalizedValue = value / 100f; // Slider deðerini 0.0 - 1.0 aralýðýna dönüþtürme
        AudioListener.volume = normalizedValue;
        volumeAmount.text = ((int)value).ToString();
    }

    private void SaveAudio()
    {
        PlayerPrefs.SetFloat("audioVolume", AudioListener.volume);
    }

    private void LoadAudio()
    {
        if (PlayerPrefs.HasKey("audioVolume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("audioVolume");
            float sliderValue = AudioListener.volume * 100f; // Ses seviyesini 0-100 aralýðýna dönüþtürme
            slider.value = sliderValue;
            volumeAmount.text = ((int)sliderValue).ToString();
        }
        else
        {
            PlayerPrefs.SetFloat("audioVolume", 0.5f);
            AudioListener.volume = PlayerPrefs.GetFloat("audioVolume");
            float sliderValue = AudioListener.volume * 100f; // Ses seviyesini 0-100 aralýðýna dönüþtürme
            slider.value = sliderValue;
            volumeAmount.text = ((int)sliderValue).ToString();
        }
    }

    private void InitializeAudio()
    {
        slider.minValue = 0;
        slider.maxValue = 100;
        LoadAudio();
    }

    //kalite
    public void SetLowQuality()
    {
        QualitySettings.SetQualityLevel(1);
    }

    public void SetMediumQuality()
    {
        QualitySettings.SetQualityLevel(2);
    }

    public void SetHighQuality()
    {
        QualitySettings.SetQualityLevel(4);
    }



    //ekran
    public void SetScreenMode(bool isFullscreen)
    {
        if (isFullscreen)
        {
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        }
        else
        {
            // Ýstediðiniz küçük ekran boyutunu burada belirleyin
            int screenWidth = 800;
            int screenHeight = 600;
            Screen.SetResolution(screenWidth, screenHeight, false);
        }
    }

    // Geri dön
    public GameObject pauseScreen;
    public string SampleScene; // Duraklatma menüsünün olduðu sahnenin adý

    public void GoBack()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
