using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private GameManager gm;
    private PlayerController playerControllerScript;
    private float leftBound = -15;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * gm.GetGameSpeed());
        }

        if (gameObject.transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
