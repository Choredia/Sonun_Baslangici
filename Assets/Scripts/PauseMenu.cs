using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject PauseButton;

    bool GamePaused;

    void Start()
    {
        GamePaused = false;
    }

    void Update()
    {
        if (GamePaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void PauseGame()
    {
        GamePaused = true;
        PauseScreen.SetActive(true);
        PauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        GamePaused = false;
        PauseScreen.SetActive(false);
        PauseButton.SetActive(true);
    }

    public void AnaMenuyeDon()
    {
        // Ana men� sahnesine d�n
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void AyarlariAc()
    {
        // Ayarlar men�s�n� a�
        SceneManager.LoadScene("DSettingsMenu");
    }

    public void CikisYap()
    {
        // Uygulamadan ��k
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
