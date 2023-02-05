using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeOut : MonoBehaviour
{

    InstantiateMaze manager;

    public void SetManager(InstantiateMaze manager)
    {
        this.manager = manager;
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "MousePoint")
        {
            Destroy(other.gameObject);
            manager.Failed();
        }
        //Application.LoadLevel("2");
    }

}
