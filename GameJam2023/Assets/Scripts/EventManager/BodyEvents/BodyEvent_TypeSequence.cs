using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyEvent_TypeSequence : BodyEvent
{
    public QTEManager typeSeqManager;
    public QTEEvent typeSeqEvent;

    public List<QTEKey> sequenceKeys = new List<QTEKey>();

    public float eventTimer;

    public override void CreateEvent(EventManager eManager, NavigationPoint point, float timeToReach, float diffPrecent)
    {
        base.CreateEvent(eManager, point, timeToReach, diffPrecent);

        int diffIndex = (int)data.sequenceCurve.Evaluate(diffPrecent);

        typeSeqManager = GetComponent<QTEManager>();
        typeSeqEvent = typeSeqManager.eventData;

        //List<QTEKey> keys = new List<QTEKey>();
        //for (int i = 0; i < data.SequenceDifficulty[diffIndex].sequenceCount; i++)
        //    keys.Add(data.possibleKeys[Random.Range(0, data.possibleKeys.Count)]);
        int keys = data.SequenceDifficulty[diffIndex].sequenceCount;
        typeSeqManager.SetSize(keys);
        typeSeqEvent.SetTSValues(data.possibleKeys, data.SequenceDifficulty[diffIndex].eventDuration);
    }

    public override void StartEvent()
    {
        base.StartEvent();

        typeSeqManager.startEvent();
    }
}
