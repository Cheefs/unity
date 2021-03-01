using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20.0f;
    private float spawnRangeZ = 20.0f;

    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        GameObject animal = animalPrefabs[animalIndex];
        Vector3 spawnPos = new Vector3(
            Random.Range(-spawnRangeX, spawnRangeX), 0, spawnRangeZ
        );
        Instantiate(animal, spawnPos, animal.transform.rotation);
    }
}
