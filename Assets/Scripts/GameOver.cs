using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;

    public Image imageGameOver;

    public int totalCristalsInScene;
    public bool isGameOver;

    private void Awake()
    {
        isGameOver = false;
        instance = this;
    }

    private void Update()
    {
        if (totalCristalsInScene == 0 && !isGameOver)
        {
            StartCoroutine("WaitForGameOver");
        }

        if (Input.GetKeyDown(KeyCode.R) && isGameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
            isGameOver = false;
        }
    }

    IEnumerator WaitForGameOver()
    {
        yield return new WaitForSeconds(0.7f);
        imageGameOver.gameObject.SetActive(true);
        Time.timeScale = 0;
        isGameOver = true;
    }
}
