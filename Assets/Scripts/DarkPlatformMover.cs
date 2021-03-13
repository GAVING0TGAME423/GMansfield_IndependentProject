using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkPlatformMover : MonoBehaviour
{

    public GameObject DarkPlatform;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime *.5f);
    }


}
