using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    [SerializeField] private float jumpForwardMovementSpeed = 2; 
    private Rigidbody myRigidbody = null;
    private float jumpForce = 5;
    private bool isGrounded = true;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerMovement();
        PlayerJump();
    }

    private void PlayerMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 playerMovement = new Vector3(horizontal, 0, 0).normalized ;
        transform.Translate(playerMovement * speed * Time.deltaTime);
    }

    private void PlayerJump()
    {
        if (isGrounded == true)
        {
            isGrounded = false;
            myRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            myRigidbody.AddForce(Vector3.forward * jumpForwardMovementSpeed, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == 8)
        {
            isGrounded = true;
        }
    }
}
