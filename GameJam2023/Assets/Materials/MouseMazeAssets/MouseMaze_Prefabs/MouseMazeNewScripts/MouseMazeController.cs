using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMazeController : MonoBehaviour
{
    float distance = 10;
    Camera cam;

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            //Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.CompareTag("MazePath"))
                {
                    Debug.Log("On path.");
                }
                else if (hit.collider.CompareTag("MazeFail"))
                {
                    Debug.Log("Fell off");
                }
            }
        }
    }
}
