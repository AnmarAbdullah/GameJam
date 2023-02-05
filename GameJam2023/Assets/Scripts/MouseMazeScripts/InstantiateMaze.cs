using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstantiateMaze : MonoBehaviour
{
    public GameObject MouseMazeGame;
    public Transform pos;
    public GameObject[] mazeToInstantiate;
    BodyEvents_Path ev;
    public MazeWin winTrigger;
    public MazeOut outTrigger;

    public float currentTime;
    public float startingTime = 10f;
    bool running;

    [SerializeField] TextMeshProUGUI countdownText;

    

    void Update()
    {
        if (running)
        {

            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                currentTime = 0;
                // Your Code Here
                Failed();
                Debug.Log("System Failure");
            }
        }
    }

    public void SetValues(float time, BodyEvents_Path eventP)
    {
        //Select Map from array of map prefabs
        //Get MazeMap Component from object
        //Run SetManager Function of MazeMap

        currentTime = time;
        winTrigger = transform.Find("WinTrigger").GetComponent<MazeWin>();
        winTrigger.SetManager(this);
        outTrigger= transform.Find("ExitTrigger").GetComponent<MazeOut>();
        outTrigger.SetManager(this);
        ev = eventP;
    }

    public void StartTimer()
    {
        running = true;
    }

    public void InstantiateMazeObject()
    {
        MouseMazeGame.SetActive(true);
        int n = Random.Range(0, mazeToInstantiate.Length);
        Instantiate(mazeToInstantiate[n], pos.position, mazeToInstantiate[n].transform.rotation);
        Debug.Log("Spawn Maze");
    }

    public void Completed()
    {
        ev.Completed();
    }

    public void Failed()
    {
        ev.Failed();
    }
}
