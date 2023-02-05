using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyEvents_Path : BodyEvent
{
    InstantiateMaze instanMaze;
    //MazeTimer timer;
    public float time;
    public override void CreateEvent(EventManager eManager, NavigationPoint point, float timeToReach)
    {
        base.CreateEvent(eManager, point, timeToReach);
        // set variable here

        instanMaze = GetComponent<InstantiateMaze>();
        //timer = GetComponentInChildren<MazeTimer>();
        //grab maze and call set value function
        instanMaze.currentTime = time;



    }

    public override void StartEvent()
    {
        base.StartEvent();

        //instanMaze.InstantiateMazeObject();

        instanMaze.outTrigger.gameObject.SetActive(true);
        instanMaze.winTrigger.gameObject.SetActive(true);
        instanMaze.StartTimer();
    }
}
