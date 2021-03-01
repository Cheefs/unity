using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRange = 9.0f;

    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
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
            Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
        }
    }

    private void SpawnPowerup()
    {
         Instantiate(powerupPrefab, GenerateRandomPosition(), powerupPrefab.transform.rotation);
    }

    private Vector3 GenerateRandomPosition()
    {
        float spawnRangeX = Random.Range(-spawnRange, spawnRange);
        float spawnRangeZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnRangeX, 0, spawnRangeZ);
    }
}
