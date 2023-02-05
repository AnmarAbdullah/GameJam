using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyEvents_Dots : BodyEvent
{
    public int amount;
    public float duration;

    ConnectDots dots;

    public override void CreateEvent(EventManager eManager, NavigationPoint point, float timeToReach, float diffPrecent)
    {
        base.CreateEvent(eManager, point, timeToReach, diffPrecent);

        int diffIndex = (int)data.dotsCurve.Evaluate(diffPrecent);

        Vector3 pos = point.transform.position;
        transform.position = pos;
        dots = GetComponent<ConnectDots>();
        dots.SetValues(data.DotsDifficulty[diffIndex].amountToSpawn, (int)data.DotsDifficulty[diffIndex].eventDuration);
    }

    public override void StartEvent()
    {
        base.StartEvent();

        dots.StartEvent();
    }
}
