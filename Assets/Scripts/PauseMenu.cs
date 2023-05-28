using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject PauseButton;

    private bool GamePaused = false;

    void Start()
    {
        GamePaused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
                ResumeGame();
            else
                PauseGame();
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void PauseGame()
    {
        GamePaused = true;
        Time.timeScale = 0f;
        PauseScreen.SetActive(true);
        PauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        GamePaused = false;
        Time.timeScale = 1f;
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
        
        Application.Quit();
    }
}
