using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 7f;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float jumpForce;
    private Rigidbody rb;
    //private Animator animator;
    private bool isGrounded;
    public LayerMask layerFloor;
    float horizontalInput;
    float verticalInput;



    void Start()
    {
        //animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }



    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            //animator.SetBool("jump", false);

        }

    }

    void Update()
    {
        // Run

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(0, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * movementSpeed * Time.deltaTime, Space.Self);

        if (horizontalInput != 0)
        {
            Quaternion toRotation = Quaternion.Euler(0, horizontalInput * rotationSpeed * Time.deltaTime, 0);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + toRotation.eulerAngles);
        }

        //animator.SetFloat("run", movementDirection.magnitude);


        // jump

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            //animator.SetBool("jump", true);

        }


    }


}
