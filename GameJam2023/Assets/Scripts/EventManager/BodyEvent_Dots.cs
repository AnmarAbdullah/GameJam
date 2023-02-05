using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyEvent_Dots : BodyEvent
{
    ConnectDots dots;

    public override void CreateEvent(EventManager eManager, NavigationPoint point, float timeToReach, float diffPrecent)
    {
        base.CreateEvent(eManager, point, timeToReach, diffPrecent);

        // Setup values;
        dots.GetComponent<ConnectDots>();
        dots.SetValues(dots.amountToSpawn, dots.Duration);

    }

    public override void StartEvent()
    {
        base.StartEvent();
        dots.StartEvent();
    }
}
