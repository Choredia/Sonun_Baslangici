using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void TekrarOyna()
    {
        // GameOver sahnesini yeniden y�kle
        SceneManager.LoadScene("Game");
    }

    public void CikisYap()
    {
        // Uygulamadan ��k
        
        Application.Quit();
    }
}
