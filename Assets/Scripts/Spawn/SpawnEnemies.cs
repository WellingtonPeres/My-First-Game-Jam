using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] arrayEnemies;
    public Transform[] arrayPositionSpawn;

    private int randomArrayEnemies;
    private int randomArrayPositionSpawn;

    private float time;
    private float timeForSpawn = 2f;

    void Update()
    {
        if (TimeWave.instance.imageWave.fillAmount >= .3f && TimeWave.instance.imageWave.fillAmount < .4f)
        {
            timeForSpawn = 1.5f;
        }
        else if (TimeWave.instance.imageWave.fillAmount >= .6f && TimeWave.instance.imageWave.fillAmount < 0.8f)
        {
            timeForSpawn = 1f;
        }

        if (!GameOver.instance.isGameOver)
        {
            time += Time.deltaTime;

            if (time > timeForSpawn && Boss.instance.totalLife > 0)
            {
                randomArrayEnemies = Random.Range(0, arrayEnemies.Length);
                randomArrayPositionSpawn = Random.Range(0, arrayPositionSpawn.Length);
                Instantiate(arrayEnemies[randomArrayEnemies], arrayPositionSpawn[randomArrayPositionSpawn].position, Quaternion.identity);

                time = 0;
            }
        }
    }
}
