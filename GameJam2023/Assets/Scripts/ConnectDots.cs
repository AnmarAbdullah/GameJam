using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ConnectDots : MonoBehaviour
{
    LineRenderer lr;
    public List<Transform> points = new List<Transform>();
    public List<Transform> Planned = new List<Transform>();
    public Transform dotsToSpawn;

    [SerializeField] public int amountToSpawn;
    [SerializeField] public float Duration;
    bool eventStarted;

    public Transform lastPoints;
    public Transform indic;


    BodyEvents_Dots ev;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        ev = GetComponent<BodyEvents_Dots>();
        //Spawn(amountToSpawn);
        //StartEvent();
    }

    public void SetValues(int amount, float duration)
    {
        amountToSpawn = amount;
        Duration = duration;
    }

    public void StartEvent()
    {
        Spawn(amountToSpawn);
        eventStarted = true;
    }

    private void Spawn(int amount)
    {
        StartCoroutine(Spawner(amount));
    }

    IEnumerator Spawner(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector2 pos = Random.insideUnitCircle * 4;

            Transform obj = Instantiate(dotsToSpawn, transform);
            obj.position = transform.position + new Vector3(pos.x, pos.y, 0);
            Planned.Add(obj);
            int e = i + 1;
            obj.GetComponentInChildren<TextMeshProUGUI>().text = e.ToString();
            yield return new WaitForSeconds(0.4f);
        }

        /*for (int i = 0; i < Planned.Count; i++)
        {
            int e = i + 1;
            Planned[i].GetComponentInChildren<TextMesh>().text = e.ToString();
        }*/
    }

    void makeLine(Transform finalpoint)
    {
        if (lastPoints == null)
        {
            lastPoints = finalpoint;
            points.Add(finalpoint);
        }
        else
        {
            points.Add(finalpoint);
            lr.enabled = true;
            setupLine();
        }
    }

    void setupLine()
    {
        int pointlength = points.Count;
        lr.positionCount = pointlength;
        for (int i = 0; i < pointlength; i++)
        {
            lr.SetPosition(i, points[i].position);
        }
    }

    void Update()
    {
        if (eventStarted)
        {
            Duration -= Time.deltaTime;
            if (Duration <= 0)
            {
                // Activate Loss Condition
                Debug.Log("loss");
                lr.enabled=false;
                ev.Failed();
                // play sound effect of fail
                eventStarted = false;
            }

            if (points != null)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    if (points[i] != Planned[i])
                    {
                        // Activate Loss Condition
                        Debug.Log("loss");
                        lr.enabled = false;
                        ev.Failed();
                        // play sound effect of fail
                        eventStarted = false;
                    }
                }
            }

            if (points.Count == Planned.Count)
            {
                //activate win condition
                lr.enabled = false;
                print("win");
                //play sound effect of win
                ev.Completed();
                eventStarted = false;
            }

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                print("Mouse Clicked");
                if (Physics.Raycast(ray, out hit, 100))
                {
                    makeLine(hit.collider.transform);
                    indic.position = hit.collider.transform.position;
                    print(hit.collider.name);
                    // play sound effect of dot clicking
                    if (hit.collider != null) { }
                }
            }
        }
    }
}
