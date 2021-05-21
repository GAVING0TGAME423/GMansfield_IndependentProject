using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mousespeed = 100f;
    public Transform playerBody;
    private float xRotation = 0f;
    private PickupScript pickupscript;

    void Start()
    {
        pickupscript = GameObject.Find("Player").GetComponent<PickupScript>();
    }

    
    void Update()
    {
        if (pickupscript.gameactive)
        {
            Cursor.lockState = CursorLockMode.Locked;
            // Mouse movement recognition
            float mouseX = Input.GetAxis("Mouse X") * mousespeed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mousespeed * Time.deltaTime;
            // mouse rotate left and right
            playerBody.Rotate(Vector3.up * mouseX);
            //moves camera up and down without moving cylinder
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
        
       
     

    }
}
