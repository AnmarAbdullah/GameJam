using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[CreateAssetMenu(menuName = "BodyEventData")]
[Serializable]
public class BodyEventDifficultyData : ScriptableObject
{
    [Header("Event Intervals")]
    public AnimationCurve intervalCurve;
    public IntervalDifficulty[] IntervalDifficulty;

    [Header("Dots")]
    public AnimationCurve dotsCurve;
    public DotsDifficulty[] DotsDifficulty;

    [Header("Sequence")]
    public AnimationCurve sequenceCurve;
    public List<QTEKey> possibleKeys;
    public SequenceDifficulty[] SequenceDifficulty;

    [Header("Path")]
    public AnimationCurve pathCurve;
    public PathDifficulty[] PathDifficulty;
}

[System.Serializable]
public class IntervalDifficulty
{
    public int minInterval;
    public int maxInterval;
    public Vector2 timeToReach;
}

[System.Serializable]
public class DotsDifficulty
{
    public int amountToSpawn;
    public float eventDuration;
}

[System.Serializable]
public class SequenceDifficulty
{
    public int sequenceCount;
    public float eventDuration;
}

[System.Serializable]
public class PathDifficulty
{
    public float eventDuration;
}
