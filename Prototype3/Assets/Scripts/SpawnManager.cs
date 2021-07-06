using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacleList;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private PlayerController playerController;
    private float startDelay = 2;
    private float repeatRate = 2;


    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void SpawnObstacle()
    {
        if (!playerController.gameOver)
        {
            GameObject randomObstacle = GetRandomObstacle();
            Instantiate(randomObstacle, spawnPos, randomObstacle.transform.rotation);
        }
    }

    GameObject GetRandomObstacle()
    {
        int rnd = Random.Range(0, obstacleList.Count);
        return obstacleList[rnd];
    }
}
