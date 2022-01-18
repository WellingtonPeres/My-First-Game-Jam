using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckGameOver : MonoBehaviour
{
    public static CheckGameOver instance;

    public Image imageGameOver;

    public int totalTreesInScene;

    private bool isGameOver = false;

    private void Start()
    {
        instance = this;
        totalTreesInScene = 5;
    }

    private void Update()
    {
        if (totalTreesInScene == 0 && isGameOver == false)
        {
            imageGameOver.gameObject.SetActive(true);
            print("GameOver");
            isGameOver = true;
        }
    }
}
