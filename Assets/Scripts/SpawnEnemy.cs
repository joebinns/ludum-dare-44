using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    //ENEMY SPAWNER
    public GameObject enemy;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    int spawned;

    void Start()
    {
        //SPAWNING
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        spawned++;

        if(spawned >= 10)
        {
            stopSpawning = true;
        }

        Instantiate(enemy, transform.position, transform.rotation);

        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
