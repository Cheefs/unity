using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] string inputID;
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
    [SerializeField] KeyCode switchKey;
    [SerializeField] List<GameObject> camerasList;
    int activeCameraIndex = 0;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);

        if(IsOnTheGround())
        {
            playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);
            speedometerText.SetText($"Speed: {speed} km/p");

            rmp = (speed % 30) * 40;
            rmpText.SetText($"Rpm: {rmp}");
        }
     
        if(Input.GetKeyDown(switchKey))
        {
            ChangeCamera();
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

    void ChangeCamera()
    {
        int prevIndex = activeCameraIndex;
        int nextIndex = activeCameraIndex < camerasList.Count - 1 ? activeCameraIndex + 1 : 0;
        activeCameraIndex = nextIndex;

        camerasList[prevIndex].SetActive(false);
        camerasList[nextIndex].SetActive(true);

    }
}
