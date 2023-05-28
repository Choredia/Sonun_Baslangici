using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public float totalTime = 61f; // Toplam s�re

    public float currentTime; // Ge�en s�re

    public void Start()
    {
        currentTime = totalTime;
    }

    public void Update()
    {
        // S�reyi azalt
        currentTime -= Time.deltaTime;

        // S�re bitti�inde GameOver sahnesine ge�i� yap
        if (currentTime <= 0f)
        {
            LoadGameOverScene();
        }
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("EndOfStory");
    }
}
