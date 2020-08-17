using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject astronaut; 

    public Transform[] spawnPoints;
    public GameObject[] asteroids;

    private float _timeBetweenSpawns;
    public float startTimeBetweenSpawns;
    
    void Update()
    {
        if (astronaut != null)
        {

            if (_timeBetweenSpawns <= 0)
            {

                Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject randomAsteroids = asteroids[Random.Range(0, asteroids.Length)];

                Instantiate(randomAsteroids, randomSpawnPoint.position, Quaternion.identity);

                _timeBetweenSpawns = startTimeBetweenSpawns;
            }
            else
            {
                _timeBetweenSpawns -= Time.deltaTime;
            }
        }

    }

}
