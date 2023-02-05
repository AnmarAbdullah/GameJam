using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyEvent_ColorOrder : BodyEvent
{
    public ColorOrderManager colorMan;

    public int sequenceLimit;
    public float sequenceDuration;

    public override void CreateEvent(EventManager eManager, NavigationPoint point, float timeToReach)
    {
        base.CreateEvent(eManager, point, timeToReach);

        colorMan = GetComponent<ColorOrderManager>();
        colorMan.SetUp(sequenceLimit, sequenceDuration);
    }

    public override void StartEvent()
    {
        base.StartEvent();

        colorMan.StartGame();
    }

}
