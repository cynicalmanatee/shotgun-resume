using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;

    public float gravity = -9.81f * 10f;

    public float jumpHeight = 3f;

    public Transform groundCheck;

    public float groundDistance = 0.4f;

    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    bool doubleJump;

    public GameManager gameManager;

    void Start()
    {
        doubleJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded =
            Physics
                .CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (!gameManager.paused)
        {
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
                doubleJump = true;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && (isGrounded || doubleJump))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

                doubleJump = (!isGrounded ? false : true);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
    }
}
