using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkPlatformMover : MonoBehaviour
{
    private PickupScript pickupscript;
    public GameObject DarkPlatform;

    void Start()
    {
        pickupscript = GameObject.Find("Player").GetComponent<PickupScript>();
    }
    void Update()
    {
        if(pickupscript.Win == false && pickupscript.Lose == false )
        {
            transform.Translate(Vector3.up * Time.deltaTime * .5f);
        }
    }


}
