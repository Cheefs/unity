using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RepeatEnvironment : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z /2;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position.z);
        Debug.Log(startPos.z - repeatWidth);
        if (transform.position.z < startPos.z - repeatWidth)
        {
            transform.position = startPos;
        }

        transform.Translate(Vector3.forward * Time.deltaTime * -50);
    }
}
