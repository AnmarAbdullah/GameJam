using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeWin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("MazeActvityComplete");
    }

}
