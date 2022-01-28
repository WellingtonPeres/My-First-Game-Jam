using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeWave : MonoBehaviour
{
    public static TimeWave instance;

    public Image imageWave;

    private void Start()
    {
        instance = this;

        StartCoroutine("WaitTimeForBoss");
    }

    IEnumerator WaitTimeForBoss()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            imageWave.fillAmount += 0.02f;

            if (imageWave.fillAmount == 1)
            {
                break;
            }
        }
    }
}
