using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public float totalTime = 61f; // Toplam süre

    public float currentTime; // Geçen süre

    public void Start()
    {
        currentTime = totalTime;
    }

    public void Update()
    {
        // Süreyi azalt
        currentTime -= Time.deltaTime;

        // Süre bittiðinde GameOver sahnesine geçiþ yap
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
