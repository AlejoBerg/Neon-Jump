using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action OnCollisionWithPlatform;

    private GameObject nextPlatform;
    private Rigidbody myRigidbody = null;
    private bool isGrounded = true;
    private int currentPlatformIndex = 0;

    [SerializeField] private float jumpForce = 4; // Cuan alto va a saltar
    [SerializeField] private GameObject[] platformsReference;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        nextPlatform = platformsReference[1];
    }

    private void Update()
    {
        PlayerJump();
        PlayerMovement();
        PlayerMovementKeyboard();//Solo para test

        if (transform.position.z < nextPlatform.transform.position.z)
        {
            print("nextPlatform.transform.position.z = " + nextPlatform.transform.position.z);
            Vector3 currentVelocity = new Vector3(0,0,5);
            Vector3 dampedPosition = Vector3.SmoothDamp(transform.position, nextPlatform.transform.position, ref currentVelocity, 0.3f);
            transform.position = dampedPosition;
        }
    }

    private void PlayerMovement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * Time.deltaTime, transform.position.y , transform.position.z);//.normalized
            }
        }
    }

    private void PlayerJump()
    {
        if (isGrounded == true)
        {
            isGrounded = false;
            myRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void PlayerMovementKeyboard()
    {
        var speed = 8;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 playerMovement = new Vector3(horizontal, 0, 0).normalized;
        transform.Translate(playerMovement * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 8)
        {
            OnCollisionWithPlatform?.Invoke();

            if(currentPlatformIndex < platformsReference.Length - 1)
            {
                currentPlatformIndex += 1;
                nextPlatform = platformsReference[currentPlatformIndex];
            }
            else
            {
                currentPlatformIndex = 0;
                nextPlatform = platformsReference[currentPlatformIndex];
            }

            isGrounded = true;
        }
    }
}
