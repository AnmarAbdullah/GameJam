using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyEvent_Dots : BodyEvent
{
    ConnectDotes dots;

    public override void CreateEvent(EventManager eManager, NavigationPoint point, float timeToReach)
    {
        base.CreateEvent(eManager, point, timeToReach);

        // Setup values;
        dots.GetComponent<ConnectDotes>();
        dots.SetValues(dots.amountToSpawn, timeToReach);

    }

    public override void StartEvent()
    {
        base.StartEvent();
        dots.StartEvent();
    }
}
