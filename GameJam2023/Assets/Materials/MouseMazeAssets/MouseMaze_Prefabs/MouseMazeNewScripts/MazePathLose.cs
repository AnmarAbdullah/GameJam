using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePathLose : MonoBehaviour
{
    public RandomMaze RM;

    void OnCollisionExit(Collision other)
    {
        Debug.Log("You fell off");

        if (other.gameObject.tag == "MousePoint")
        {
            Destroy(other.gameObject);
            Debug.Log("Maze Lose");
        }
    }

    void Start()
    {
        RM = GetComponentInParent<RandomMaze>();
        if (RM != null)
        {
            Debug.Log("RandomMazeFound");
        }
    }
}
