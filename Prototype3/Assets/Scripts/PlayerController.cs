using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnim;
    private AudioSource playerAudio;
    private Rigidbody playerRb;
    private bool isOnTheGround;
    public bool gameOver;

    public float jumpForce = 10f;
    public float gravityModifier;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnTheGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                {
                    isOnTheGround = true;
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
        }
    }
}
