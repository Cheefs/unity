using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFly : MonoBehaviour
{
    public Vector3 planeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( planeSpeed != null )
        {
            this.transform.position += planeSpeed;
        }

    }
}
