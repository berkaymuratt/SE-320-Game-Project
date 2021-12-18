using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptA : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
        GameObject cube_B = GameObject.Find("CubeB"); 
        
        Rigidbody rigidbody = cube_B.GetComponent<Rigidbody>();

        print(rigidbody.isKinematic.ToString());
        
        rigidbody.isKinematic = true;
        
        print(rigidbody.isKinematic.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
    }
}
