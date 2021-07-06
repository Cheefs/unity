using UnityEngine;

public class Weel : MonoBehaviour
{
    public int speed = 50;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Rotate());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, speed);
    }
}
