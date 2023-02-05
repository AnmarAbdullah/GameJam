using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRotator : MonoBehaviour
{
    private void Update()
    {
       // Debug.Log("hello");
    }

    private void OnTriggerStay(Collider other)
    {
        print("hello");
        if(other.gameObject.tag == "Rotator")
        {
            Debug.Log("HEllo");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("got it");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("hello");
    }
}
