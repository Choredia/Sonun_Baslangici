using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OyunaBasla()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void CikisYap()
    {
        // Uygulamadan ��k
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void AyarlaraGit()
    {
        SceneManager.LoadScene("ASettingsMenu");
    }
}
