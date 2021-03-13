using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbPlacement : MonoBehaviour
{
    public GameObject[] OrbLocate;
    public GameObject prefab;
    public Vector3 offset = new Vector3(0, 2, 0);

    void Start()
    {
        int orbIndex = Random.Range(0, OrbLocate.Length);
        Instantiate(prefab, OrbLocate[orbIndex].transform.position + offset, Quaternion.identity);
    }

    
    void Update()
    {
        
    }

}
