using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForwardMovementSpeed = 2; //Cuanto se va a mover para adelante cuando salta
    [SerializeField] private float jumpForce = 5; // Cuan alto va a saltar

    private Rigidbody myRigidbody = null;
    private bool isGrounded = true;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerMovement();
        PlayerMovementKeyboard();//Solo para test
        PlayerJump();
    }

    private void PlayerMovement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * Time.deltaTime, transform.position.y , transform.position.z);
            }
        }
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

    private void PlayerMovementKeyboard()
    {
        var speed = 5;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 playerMovement = new Vector3(horizontal, 0, 0).normalized;
        transform.Translate(playerMovement * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == 8)
        {
            isGrounded = true;
        }
    }
}
