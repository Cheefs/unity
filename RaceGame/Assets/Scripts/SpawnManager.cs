using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerup;

    private float startDelay = 1.0f;
    private float zRange = 8.0f;
    private float xRange = 19.0f;
    private float ySpawn = 0.6f;

    private float enemyInterval = 1.0f;
    private float powerupInterval = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, enemyInterval);
        InvokeRepeating("SpawnPowerup", startDelay, powerupInterval);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-xRange, xRange);
        int randomIndex = Random.Range(0, enemies.Length);
        GameObject randomEnemy = enemies[randomIndex];

        Instantiate(randomEnemy, new Vector3(randomX, ySpawn, zRange), randomEnemy.transform.rotation);
    }

    void SpawnPowerup()
    {
        Vector3 a = new Vector3();
        float randomX = Random.Range(-xRange, xRange);
        Instantiate(powerup, new Vector3(randomX, ySpawn, zRange), powerup.transform.rotation);
    }
}
