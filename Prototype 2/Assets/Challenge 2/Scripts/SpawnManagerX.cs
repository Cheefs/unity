using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    const int MIN_SPAWN_INTERVAL = 3;
    const int MAX_SPAWN_INTERVAL = 6;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = MIN_SPAWN_INTERVAL;

    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }

    private void Update()
    {
        UpdateSpawnInterwal();
    }

    private void UpdateSpawnInterwal()
    {
        spawnInterval = Random.Range(MIN_SPAWN_INTERVAL, MAX_SPAWN_INTERVAL);
    }

    // Spawn random ball at random x position at top of play area
    private void SpawnRandomBall ()
    {
        Debug.Log(spawnInterval);
        int randomIndex = Random.Range(0, ballPrefabs.Length);
        GameObject selectedBall = ballPrefabs[randomIndex];
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(selectedBall, spawnPos, selectedBall.transform.rotation);
    }

}
