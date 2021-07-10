using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRange = 9.0f;

    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] List<GameObject> powerupPrefabs;
    public GameObject bossPrefab;
    public GameObject[] miniEnemyPrefabs;
    public int bossRound;

    public int enemyCount;
    public int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            //Spawn a boss every x number of waves
            if (waveNumber % bossRound == 0)
            {
                SpawnBossWave(waveNumber);
            }
            else
            {
                SpawnEnemyWave(waveNumber);
            }
            //Updated to select a random powerup prefab for the Medium Challenge
            int randomPowerup = Random.Range(0, powerupPrefabs.Count);
            Instantiate(powerupPrefabs[randomPowerup], GenerateRandomPosition(),
            powerupPrefabs[randomPowerup].transform.rotation);
        }
    }


    private void SpawnEnemyWave(int count)
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

    void SpawnBossWave(int currentRound)
    {
        int miniEnemysToSpawn;
        //We dont want to divide by 0!
        if (bossRound != 0)
        {
            miniEnemysToSpawn = currentRound / bossRound;
        }
        else
        {
            miniEnemysToSpawn = 1;
        }
        var boss = Instantiate(bossPrefab, GenerateRandomPosition(),
        bossPrefab.transform.rotation);
        boss.GetComponent<Enemy>().miniEnemySpawnCount = miniEnemysToSpawn;
    }

    public void SpawnMiniEnemy(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int randomMini = Random.Range(0, miniEnemyPrefabs.Length);
            Instantiate(miniEnemyPrefabs[randomMini], GenerateRandomPosition(),
            miniEnemyPrefabs[randomMini].transform.rotation);
        }
    }


}
