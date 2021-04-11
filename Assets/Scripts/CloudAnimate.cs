using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudAnimate : MonoBehaviour
{
    private Animator Animcloud;
    private PickupScript pickupscript;

    void Start()
    {
        Animcloud = GetComponent<Animator>();
        pickupscript = GameObject.Find("Player").GetComponent<PickupScript>();
    }

    private void Update()
    {
        if (pickupscript.Win == true || pickupscript.Lose == true)
        {
            Animcloud.SetBool("Landing", true);
        }


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Animcloud.SetBool("Landing", true);
            Debug.Log("touching cloud");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Animcloud.SetBool("Landing", false);
            Debug.Log("leaving cloud");
        }
    }
}
