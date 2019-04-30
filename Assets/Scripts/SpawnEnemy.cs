using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnEnemy : MonoBehaviour
{
    //ENEMY SPAWNER
    public GameObject enemy;
    public bool stopSpawning = false;

    private float spawnTime;
    private float spawnDelay;

    int maxSpawn;

    int spawned;

    void Start()
    {
        System.Random rnd = new System.Random();

        maxSpawn = rnd.Next(1, 8);

        spawnDelay = rnd.Next(0, 5);

        spawnTime = rnd.Next(0, 3);

        //SPAWNING
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        spawned++;

        if (spawned >= maxSpawn)
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
