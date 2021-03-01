using UnityEngine;
using System;

public class PropellerRotation : MonoBehaviour
{
    private float rotationSpeed = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed);
    }
}
