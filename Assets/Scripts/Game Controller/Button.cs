using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameObject backgroundMusic;

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        DontDestroyOnLoad(backgroundMusic);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
}
