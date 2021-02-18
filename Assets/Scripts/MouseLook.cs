using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mousespeed = 100f;
    public Transform playerBody;
    private float xRotation = 0f;

    void Start()
    {
        //cursor disappears when game starts
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
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
}
