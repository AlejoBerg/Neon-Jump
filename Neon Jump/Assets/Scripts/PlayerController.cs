using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject [] platformsReference;
    private Queue<GameObject> platformsQueue;
    private GameObject nextPlatform;

    [SerializeField] private float jumpForwardMovementSpeed = 2; //Cuanto se va a mover para adelante cuando salta
    [SerializeField] private float jumpForce = 4; // Cuan alto va a saltar

    private Rigidbody myRigidbody = null;
    private bool isGrounded = true;

    private void Start()
    {
        platformsQueue = new Queue<GameObject>();
        myRigidbody = GetComponent<Rigidbody>();
        
        foreach (var platform in platformsReference)
        {
            platformsQueue.Enqueue(platform);
        }

        nextPlatform = platformsQueue.Peek();

    }

    private void Update()
    {
        PlayerJump();
        PlayerMovement();
        PlayerMovementKeyboard();//Solo para test

        if (transform.position.z < nextPlatform.transform.position.z)
        {
            Vector3 currentVelocity = new Vector3(0,0,5);
            Vector3 dampedPosition = Vector3.SmoothDamp(transform.position, nextPlatform.transform.position, ref currentVelocity, 0.3f);
            transform.position = dampedPosition;
            //float smoothTime = 5;
            //var dampedPos = Mathf.SmoothDamp(transform.position.z, nextPlatform.transform.position.z, ref smoothTime, 2f);
            //transform.position = new Vector3(transform.position.x, transform.position.y, dampedPos);
        }
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
            nextPlatform = platformsQueue.Peek();
            var diff = Mathf.Abs(Mathf.Abs(this.transform.position.z) - Mathf.Abs(nextPlatform.transform.localPosition.z));

            myRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            //myRigidbody.velocity *= 0f;
            platformsQueue.Dequeue();
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
