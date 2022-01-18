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

    void Update()
    {
        time += Time.deltaTime;

        if (time > 2f)
        {
            randomArrayEnemies = Random.Range(0, arrayEnemies.Length);
            randomArrayPositionSpawn = Random.Range(0, arrayPositionSpawn.Length);
            Instantiate(arrayEnemies[randomArrayEnemies], arrayPositionSpawn[randomArrayPositionSpawn].position, Quaternion.identity);

            time = 0;
        }
    }
}
