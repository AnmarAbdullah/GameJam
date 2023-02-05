using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeWin : MonoBehaviour
{

    InstantiateMaze manager;

    public void SetManager(InstantiateMaze manager)
    {
        this.manager = manager;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("MazeActivityComplete");
        manager.Completed();
    }

}
