using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask; 
    public bool isGrounded; 
    private void OnTriggerStay(Collider other)
    {
        //Check if the player is in contact with the ground.
        isGrounded = other != null && (((1 << other.gameObject.layer) & groundMask) != 0); 
    }

    private void OnTriggerExit(Collider other)
    {   //If the player loses contact with the ground
        isGrounded = false;
    }
}
