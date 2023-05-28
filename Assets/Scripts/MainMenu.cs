using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OyunaBasla()
    {
        SceneManager.LoadScene("Game");
    }

    public void CikisYap()
    {
        // Uygulamadan çýk
        Application.Quit();
    }

    public void AyarlaraGit()
    {
        SceneManager.LoadScene("ASettingsMenu");
    }
}
