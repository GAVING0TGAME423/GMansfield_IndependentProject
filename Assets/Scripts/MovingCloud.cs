using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCloud : MonoBehaviour
{
    
    void Start()
    {
        InvokeRepeating("MoveCloudAway", 1, 10);
        InvokeRepeating("MoveCloudToward", 5, 10);
    }

   
    void Update()
    {
        
    }

    void MoveCloudAway()
    {
        transform.position = new Vector3(46.6f, 9.5f, 33f);

    }
    void MoveCloudToward()
    {
        transform.position = new Vector3(39.5f, 9.5f, 33f);

    }
}
