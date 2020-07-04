using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [Header("Ship Varibles")]
    public float thrust = 6f;
    public float rotationSpeed = 10f;

    private float verticalInput;
    private float horizontalInput;
    private Rigidbody2D rb;
    public Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");           // Get the vertical input
        horizontalInput = Input.GetAxisRaw("Horizontal");       // Get the horizontal input

        if (horizontalInput <= -0.2 || horizontalInput >= 0.2 || verticalInput >= 0.2)
        {
            // Fire bullets maybe
        }
    }

    public void FixedUpdate()
    {
        if (verticalInput >= 0.2)
        {
            rb.AddRelativeForce(Vector2.up * thrust);
        }

        if (horizontalInput <= -0.2 || horizontalInput >= 0.2 || verticalInput >= 0.2)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }



        // More skid type rotation ideal for a car project 
        //rb.AddTorque(-horizontalInput * rotationSpeed * Time.fixedDeltaTime);
        transform.Rotate(Vector3.forward * -horizontalInput * rotationSpeed);
    }
}
