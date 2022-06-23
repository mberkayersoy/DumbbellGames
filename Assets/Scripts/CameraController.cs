using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSens;
    private Transform parent; //Reference to the player.

    private void Start()
    {
        parent = transform.parent;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime; 
        parent.Rotate(Vector3.up, mouseX); //Vector3.up should be used as we will rotate the character in Y axis.
    }


}
