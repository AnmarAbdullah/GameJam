using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideFix : MonoBehaviour
{
    
    private void OnTriggerStay(Collider other)
    {
        transform.Translate(Vector3.right * 100 * Time.deltaTime);
    }
}
