using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private float rotateSpeed = 10.0f;
    private float speedStep = 0.1f;
    private Vector3 position = new Vector3(0, 0, 0);
    private Vector3 scale = Vector3.one * 2f;

    public float changeColorInterval = 1.0f;


    void Start()
    {
        transform.position = position;
        transform.localScale = scale;

        Renderer.material.color = SetRandomColor();
        InvokeRepeating("ChangeColor", 1, changeColorInterval);
    }

    void Update()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime, 0.0f, 0.0f);
        rotateSpeed += speedStep;
    }

    private void ChangeColor()
    {
        Renderer.material.color = SetRandomColor();
    }

    private Color SetRandomColor()
    {
        float r = Random.Range(0.0f, 1.0f);
        float g = Random.Range(0.0f, 1.0f);
        float b = Random.Range(0.0f, 1.0f);
        float a = GetRandomRange();

        return new Color(r,g,b,a);
    }

    private float GetRandomRange()
    {
        return Random.Range(0.0f, 1.0f);
    }
}
