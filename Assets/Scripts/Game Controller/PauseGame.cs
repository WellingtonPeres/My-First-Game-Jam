using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public static PauseGame instance;

    public Image imagePause;

    public bool isPause = false;

    private void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (!Win.instance.isWin && !GameOver.instance.isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isPause)
                {
                    Time.timeScale = 0;
                    imagePause.gameObject.SetActive(true);
                    isPause = true;
                }
                else
                {
                    Time.timeScale = 1;
                    imagePause.gameObject.SetActive(false);
                    isPause = false;
                }
            }
        }
    }
}
