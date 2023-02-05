using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePathWin : MonoBehaviour
{

    public RandomMaze RM;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "MousePoint")
        {
            Debug.Log("Maze Won");
        }
    }

    void Start()
    {
        RM = GetComponentInParent<RandomMaze>();
    }

}
