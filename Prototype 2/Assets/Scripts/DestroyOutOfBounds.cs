using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float leftBound = 25;
    private float lowerBound = -10;
    [SerializeField] GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound )
        {
            gameObject.SetActive(false);
        }
        else if (transform.position.z < lowerBound || transform.position.x > leftBound || transform.position.x < -leftBound)
        {
            gm.DecreaseLives();
            Destroy(gameObject);
        }
    }
}
