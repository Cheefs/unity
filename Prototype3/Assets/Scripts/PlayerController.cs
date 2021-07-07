using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] protected Animator playerAnim;
    [SerializeField] protected AudioSource playerAudio;
    [SerializeField] protected Rigidbody playerRb;
    [SerializeField] public bool gameOver;
    [SerializeField] protected float jumpForce;
    [SerializeField] protected float gravityModifier;
    [SerializeField] protected ParticleSystem explosionParticle;
    [SerializeField] protected ParticleSystem dirtParticle;
    [SerializeField] protected AudioClip jumpSound;
    [SerializeField] protected AudioClip crashSound;
    [SerializeField] protected private int jumpCount = 2;
    [SerializeField] protected GameManager gm;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;

        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0 && !gameOver)
        {
            jumpCount--;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }


        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyUp(KeyCode.F))
        {
            gm.ToggleDash();

            playerAnim.SetFloat("Speed_Multiplier", gm.IsDashMode() ? 2.0f : 1.0f);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        switch (collision.gameObject.tag)
        {
            case "Ground":
            {
                jumpCount = 2;
                if (!gameOver)
                {
                    dirtParticle.Play();
                }
                return;
            }
            case "Obstacle":
            {
                Debug.Log("game over");
                gameOver = true;
                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);
                explosionParticle.Play();
                dirtParticle.Stop();
                playerAudio.PlayOneShot(crashSound, 1.0f);
                return;
            }
            case "Sensor":
            {
                gm.UpdateScore(10);
                return;
            }
        }
    }
}
