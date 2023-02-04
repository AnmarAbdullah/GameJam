using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BodyEvent : MonoBehaviour
{

    EventManager manager;
    Navigation nav;
    public NavigationPoint eventPoint { get; private set; }
    float TimeToReachEvent;
    float reachTimer;
    bool reachTime;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (reachTime)
        {
            if (reachTimer >= TimeToReachEvent)
            {
                //Took Too Long to get there
                Debug.Log("Took Too Long To Reach Point;");
                manager.EventFailed(this);   
            }
            else
                reachTimer += Time.deltaTime;
        }
    }

    public virtual void CreateEvent(EventManager eManager, NavigationPoint point, float timeToReach)
    {
        manager = eManager;
        eventPoint = point;

        TimeToReachEvent = timeToReach;
        reachTimer = 0;
        reachTime = true;
    }

    public virtual void StartEvent()
    {
        reachTime = false;
        Debug.Log("Player Started Event");
    }

    public void Completed()
    {
        manager.EventCompleted(this);
    }

    public void Failed()
    {
        manager.EventFailed(this);
    }
}
