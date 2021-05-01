using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    Vector3 velocity;
    public float gravity = -9.81f;
    public float jumpheight = 3f;
    public Transform groundcheck;
    public float grounddistance = 0.4f;
    public LayerMask groundmask;
    bool isgrounded;
    private PickupScript pickupscript;
    

     void Start()
    {
        pickupscript  = GameObject.Find("Player").GetComponent<PickupScript>();
        
    }
    void Update()
    {
        isgrounded = Physics.CheckSphere(groundcheck.position, grounddistance, groundmask);
        if (isgrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //this moves the character locally based on where you look 
        Vector3 move = transform.right * x + transform.forward * z;

        //connects the controller
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isgrounded && !pickupscript.Wings)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }
        
        else if (Input.GetButtonDown("Jump") && pickupscript.Wings)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
            pickupscript.asPlayer.PlayOneShot(pickupscript.WingedJump, 1);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
