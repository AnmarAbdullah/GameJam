using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public int lives;
    int PlayerLives;
    bool gameOver;

    public int maxEvents;
    List<BodyEvent> activeEvents;
    public GameObject[] eventPrefabs;

    public Vector2 eventIntervalRange;
    float intervalTimer;
    float intervalPeriod;
    bool runInterval = true;

    public float TimeToReachEvent;

    public List<NavigationPoint> BodyAreas;

    // Start is called before the first frame update
    void Start()
    {
        activeEvents = new List<BodyEvent>();
        PlayerLives = lives;

        SetIntervalTime();
        //BodyAreas.AddRange(FindObjectsOfType<NavigationPoint>());

        //for (int i = 0; i < BodyAreas.Count; i++)
        //    if (BodyAreas[i].isBrain)
        //    {
        //        BodyAreas.RemoveAt(i);
        //        break;
        //    }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerLives > 0)
        {

            if (runInterval && activeEvents.Count <= maxEvents)
            {
                if (intervalTimer >= intervalPeriod)
                {
                    CreateEvent();
                    SetIntervalTime();
                }
                else
                    intervalTimer += Time.deltaTime;
            }
        }
        else
        {
            if (!gameOver)
            {
                Debug.Log("Player Out of Lives");
                gameOver = true;
            }
        }
    }

    void SetIntervalTime()
    {
        intervalPeriod = Random.Range(eventIntervalRange.x, eventIntervalRange.y);
        intervalTimer = 0;
        runInterval = true;
    }

    void CreateEvent()
    {
        int type = Random.Range(0, eventPrefabs.Length);
        NavigationPoint eventPoint = BodyAreas[Random.Range(0, BodyAreas.Count)];

        GameObject eventInstance = Instantiate(eventPrefabs[type], eventPoint.eventRoot.transform);
        BodyEvent instanceEvent = eventInstance.GetComponent<BodyEvent>();

        instanceEvent.CreateEvent(this, eventPoint, TimeToReachEvent);
        activeEvents.Add(instanceEvent);

        Debug.Log("Event Created at: " + eventPoint.name);
    }

    public void EventCompleted(BodyEvent bodyEvent)
    {
        activeEvents.Remove(bodyEvent);
        Destroy(bodyEvent.gameObject);
    }

    public void EventFailed(BodyEvent bodyEvent)
    {
        PlayerLives--;
        activeEvents.Remove(bodyEvent);
        Destroy(bodyEvent.gameObject);
    }
}
