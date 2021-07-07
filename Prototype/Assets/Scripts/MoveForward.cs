using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] float speed = 10;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
