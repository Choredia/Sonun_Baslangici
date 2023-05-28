using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void TekrarOyna()
    {
        // GameOver sahnesini yeniden yükle
        SceneManager.LoadScene("Game");
    }

    public void CikisYap()
    {
        // Uygulamadan çýk
        
        Application.Quit();
    }
}
