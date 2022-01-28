using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public static Win instance;

    public Image ImageWinner;

    public bool isWin = false;

    private void Start()
    {
        instance = this;
    }

    private void OnEnable()
    {
        Boss.onWinner += Winner;
    }

    private void Winner()
    {
        ImageWinner.gameObject.SetActive(true);
        isWin = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && isWin)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            isWin = false;
        }
    }
}
