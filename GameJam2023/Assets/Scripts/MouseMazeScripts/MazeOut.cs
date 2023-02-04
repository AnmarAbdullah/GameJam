using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeOut : MonoBehaviour
{

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "MousePoint")
        {
            Destroy(other.gameObject);
        }
        //Application.LoadLevel("2");
    }

}
