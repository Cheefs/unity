using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] GameObject spawnItemPrefab;
    [SerializeField] float spawnRate;
    [SerializeField] float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnItem", spawnTime, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnItem()
    {
        int rnd = Random.Range(0, spawnPoints.Length);
        GameObject rndSpawn = spawnPoints[rnd];

        Instantiate(spawnItemPrefab, rndSpawn.transform.position, spawnItemPrefab.transform.rotation);
    }
}
