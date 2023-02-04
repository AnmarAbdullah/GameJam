using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateMaze : MonoBehaviour
{
    public Transform pos;
    public GameObject[] mazeToInstantiate;

    private void Start()
    {
        InstantiateMazeObject();
    }

    private void InstantiateMazeObject()
    {
        int n = Random.Range(0, mazeToInstantiate.Length);
        Instantiate(mazeToInstantiate[n], pos.position, mazeToInstantiate[n].transform.rotation);
    }
}
