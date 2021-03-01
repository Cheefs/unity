using UnityEngine;

public class BallScript : MonoBehaviour
{
    private System.Random rnd;
    public int minPosX, maxPosX;
    public int minPosY, maxPosY;

    // Start is called before the first frame update
    void Start()
    {
        rnd = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        if( transform.position.y < minPosY )
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        int newY = rnd.Next(maxPosY, maxPosY * 2);
        int newX = rnd.Next(minPosX, maxPosX);

        transform.position = new Vector2(newX, newY);
    }
}
