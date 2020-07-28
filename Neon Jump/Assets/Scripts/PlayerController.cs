using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0; //Velocidad de izquierda a derecha 
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
