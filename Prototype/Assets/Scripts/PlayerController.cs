using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private int rmp;
    [SerializeField] private float horsePower = 20.0f;
    [SerializeField] private const float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rmpText;
    [SerializeField] List<WheelCollider> wheels;


    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if(IsOnTheGround())
        {
            playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);
            speedometerText.SetText($"Speed: {speed} km/p");

            rmp = (speed % 30) * 40;
            rmpText.SetText($"Rpm: {rmp}");
        }

    }

    bool IsOnTheGround()
    {
        foreach (WheelCollider wheel in wheels)
        {
            if(!wheel.isGrounded)
            {
                return false;
            }
        }
        return true;
    }
}
