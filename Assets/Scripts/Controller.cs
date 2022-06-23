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
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = movement * speedForce * Time.deltaTime;

        /*float horizontalMove = Input.GetAxis("Horizontal"); //Horizontal Input.
        float verticalMove = Input.GetAxis("Vertical"); //Vertical Input.

        Vector3 playerMovement = new Vector3(horizontalMove, 0f, verticalMove) * speedForce * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self); //The code that moves the character.*/

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) //If the character is on the ground and the space key is pressed.
         {
             rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
         }

         if (Input.GetKeyDown(KeyCode.LeftShift))
         {
             speedForce = 15;
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
