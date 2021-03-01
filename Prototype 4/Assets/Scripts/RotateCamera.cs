using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizonSpeed = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizonSpeed * rotationSpeed * Time.deltaTime);
    }
}
