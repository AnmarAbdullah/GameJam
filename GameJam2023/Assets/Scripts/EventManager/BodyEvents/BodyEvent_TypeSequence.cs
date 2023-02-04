using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyEvent_TypeSequence : BodyEvent
{
    public QTEManager typeSeqManager;
    public QTEEvent typeSeqEvent;

    public List<QTEKey> sequenceKeys = new List<QTEKey>();

    public float eventTimer;

    public override void CreateEvent(EventManager eManager, NavigationPoint point, float timeToReach)
    {
        base.CreateEvent(eManager, point, timeToReach);

        typeSeqManager = GetComponent<QTEManager>();
        typeSeqEvent = typeSeqManager.eventData;

        typeSeqEvent.SetTSValues(sequenceKeys, eventTimer);
    }

    public override void StartEvent()
    {
        base.StartEvent();

        typeSeqManager.startEvent();
    }
}
