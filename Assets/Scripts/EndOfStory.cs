using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfStory : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadGameOverScene();
        }
    }

    private void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}