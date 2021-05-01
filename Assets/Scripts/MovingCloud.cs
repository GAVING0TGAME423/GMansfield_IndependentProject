using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCloud : MonoBehaviour
{
    
    void Start()
    {
        //InvokeRepeating("MoveCloudAway", 1, 10);
        // InvokeRepeating("MoveCloudToward", 5, 10);

        //test code
        
        StartCoroutine(CloudMove2());

    }

   
    void Update()
    {
        
    }

    void MoveCloudAway()
    {
        transform.position = new Vector3(46.6f, 1f, 33f);

    }
    void MoveCloudToward()
    {
        transform.position = new Vector3(46.6f, 9.5f, 33f);

    }

    
    IEnumerator CloudMove()
    {
        yield return new WaitForSeconds(2);
        transform.position = new Vector3(46.6f, 1f, 33f);
        yield return new WaitForSeconds(2);
        transform.position = new Vector3(46.6f, 9.5f, 33f);
        StartCoroutine(CloudMove());

    }

    IEnumerator CloudMove2()
    {
        for (float y = 9.5f; y > 1; y -=.5f)
        {
            Debug.Log(y);
            transform.position = new Vector3(46.6f, y , 33f);
            yield return new WaitForSeconds(.5f);
        }
        for (float y = 1; y < 9.5; y += .5f)
        {
            Debug.Log(y);
            transform.position = new Vector3(46.6f, y, 33f);
            yield return new WaitForSeconds(.5f);
        }
        StartCoroutine(CloudMove2());
    }
}