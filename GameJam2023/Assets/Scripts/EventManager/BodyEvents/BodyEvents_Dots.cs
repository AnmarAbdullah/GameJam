using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyEvents_Dots : BodyEvent
{
    public int amount;
    public float duration;

    ConnectDots dots;

    public override void CreateEvent(EventManager eManager, NavigationPoint point, float timeToReach)
    {
        base.CreateEvent(eManager, point, timeToReach);

        transform.position = point.transform.position;
        dots = GetComponent<ConnectDots>();
        dots.SetValues(amount, (int)duration);
    }

    public override void StartEvent()
    {
        base.StartEvent();

        dots.StartEvent();
    }
}
