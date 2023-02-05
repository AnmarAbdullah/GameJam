using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyEvent_Rotater : BodyEvent
{
    RotatePuzzle rotpuzzle;
    public override void CreateEvent(EventManager eManager, NavigationPoint point, float timeToReach, float diffPrecent)
    {
        base.CreateEvent(eManager, point, timeToReach, diffPrecent);
        rotpuzzle = GetComponent<RotatePuzzle>();
    }

    public override void StartEvent()
    {
        base.StartEvent();

        rotpuzzle.StartEvent();
    }
}
