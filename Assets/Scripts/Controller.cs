using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speedForce = 8;
    [SerializeField] float jumpForce = 4;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 playerMovement = new Vector3(horizontalMove, 0f, verticalMove) * speedForce * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedForce = 12;
        }
        else
        {
            speedForce = 8;
        }
    }

    public bool IsGrounded()
    {
        //Function that returns the player's contact with the ground.
        return transform.Find("GroundChecker").GetComponent<GroundChecker>().isGrounded;

    }

}
