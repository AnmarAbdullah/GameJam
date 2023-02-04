using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{

    public GameObject Camera;
    public NavigationPoint startingPoint;
    public NavigationPoint currentPoint { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        SetPosition(startingPoint);
    }

    public void SetPosition(NavigationPoint point)
    {
        Debug.Log("Player Moving to: " + point.name);
        currentPoint = point;
        Camera.transform.position = new Vector3(point.transform.position.x, point.transform.position.y, -10);
    }
}
