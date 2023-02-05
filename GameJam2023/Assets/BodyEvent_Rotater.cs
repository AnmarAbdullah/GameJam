using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyEvent_Rotater : BodyEvent
{
    RotatePuzzle rotpuzzle;
    public override void CreateEvent(EventManager eManager, NavigationPoint point, float timeToReach, float diffPrecent)
    {
        base.CreateEvent(eManager, point, timeToReach, diffPrecent);

        int diffIndex = (int)data.dotsCurve.Evaluate(diffPrecent);

        rotpuzzle = GetComponent<RotatePuzzle>();
        rotpuzzle.SetUp((int)data.RotateDifficulty[diffIndex].speed, data.RotateDifficulty[diffIndex].eventDuration);
    }

    public override void StartEvent()
    {
        base.StartEvent();

        rotpuzzle.StartEvent();
    }
}
