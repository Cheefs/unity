using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRange = 9.0f;

    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] List<GameObject> powerupPrefabs;
    public int enemyCount;
    public int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy(waveNumber);
        SpawnPowerup();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            SpawnEnemy(++waveNumber);
            SpawnPowerup();
        }
    }

    private void SpawnEnemy(int count)
    {
        for(int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Count);
            GameObject enemy = enemyPrefabs[randomIndex];

            Instantiate(enemy, GenerateRandomPosition(), enemy.transform.rotation);
        }
    }

    private void SpawnPowerup()
    {
        int randomIndex = Random.Range(0, powerupPrefabs.Count);
        GameObject powerupPrefab = powerupPrefabs[randomIndex];
        Instantiate(powerupPrefab, GenerateRandomPosition(), powerupPrefab.transform.rotation);
    }

    private Vector3 GenerateRandomPosition()
    {
        float spawnRangeX = Random.Range(-spawnRange, spawnRange);
        float spawnRangeZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnRangeX, 0, spawnRangeZ);
    }
}
