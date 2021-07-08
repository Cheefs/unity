using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{ 
    struct SpawnProps
    {
        public float[] posX;
        public float[] posY;
        public float[] posZ;
        public Vector3 rotation;
    }

    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20.0f;
    private float spawnRangeZ = 20.0f;

    private float startDelay = 2.0f;
    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] List<SpawnProps> spawnPosList;
    [SerializeField] GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        spawnPosList = new List<SpawnProps> {
            new SpawnProps() {
                posX = new float[2] { -spawnRangeX/2, spawnRangeX/2 },
                posY = new float[2] { 0, 0 },
                posZ = new float[2] { spawnRangeZ, spawnRangeZ },
            },
            new SpawnProps() {
                posX = new float[2] { spawnRangeX, spawnRangeX },
                posY = new float[2] { 0, 0 },
                posZ = new float[2] { -spawnRangeZ / 2, spawnRangeZ /2 },
                rotation = new Vector3(0,90,0)
            },
             new SpawnProps() {
                posX = new float[2] { -spawnRangeX, -spawnRangeX },
                posY = new float[2] { 0, 0 },
                posZ = new float[2] { -spawnRangeZ /2, spawnRangeZ/2 },
                rotation = new Vector3(0,-90,0)
            },
        };

        InvokeRepeating("Spawn", startDelay, spawnInterval);
    }


    void Spawn()
    {
        if(!gm.IsGameRunning())
        {
            return;
        }

        int spawPosIndex = Random.Range(0, spawnPosList.Count);
        SpawnProps spawnParams = spawnPosList[spawPosIndex];

        int animalIndex = Random.Range(0, animalPrefabs.Length);
        GameObject animal = animalPrefabs[animalIndex];
        Vector3 spawnPos = new Vector3(
            Random.Range(spawnParams.posX[0], spawnParams.posX[1]),
            Random.Range(spawnParams.posY[0], spawnParams.posY[1]),
            Random.Range(spawnParams.posZ[0], spawnParams.posZ[1])
        );

        Debug.Log(spawPosIndex);
        Quaternion rotation = spawnParams.rotation != null ? Quaternion.Euler(spawnParams.rotation) : animal.transform.rotation;
        Instantiate(animal, spawnPos, rotation * animal.transform.rotation);
    }
}
