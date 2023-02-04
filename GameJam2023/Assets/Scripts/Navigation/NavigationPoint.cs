using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationPoint : MonoBehaviour
{
    public bool isBrain;

    public NavigationPoint[] ConnectedPoints;
    public GameObject aimRoot;
    public GameObject aimPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if (aimRoot != null)
        {
            for (int i = 0; i < ConnectedPoints.Length; i++)
            {
                GameObject aim = Instantiate(aimPrefab, aimRoot.transform);
                aim.GetComponent<NavAimPoint>().AimAtPoint(ConnectedPoints[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (ConnectedPoints != null)
            for (int i = 0; i < ConnectedPoints.Length; i++)
                Gizmos.DrawLine(transform.position, ConnectedPoints[i].transform.position);
    }
}
