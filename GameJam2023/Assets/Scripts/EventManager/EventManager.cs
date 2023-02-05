using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventManager : MonoBehaviour
{
    public BodyEventDifficultyData data;

    public int lives;
    int PlayerLives;
    bool gameOver;
    public Slider LifeSlider;

    public float GameDuration;
    public TMP_Text timerText;
    float GameTimer;
    bool gameComplete;

    public int maxEvents;
    List<BodyEvent> activeEvents;
    public GameObject[] eventPrefabs;

    public Vector2 eventIntervalRange;
    float intervalTimer;
    float intervalPeriod;
    bool runInterval = true;

    public float TimeToReachEvent;

    public List<NavigationPoint> BodyAreas;

    // Start is called before the first frame update
    void Start()
    {
        activeEvents = new List<BodyEvent>();
        PlayerLives = lives;
        LifeSlider.maxValue = lives;
        LifeSlider.value = lives;

        SetIntervalTime();
        //BodyAreas.AddRange(FindObjectsOfType<NavigationPoint>());

        //for (int i = 0; i < BodyAreas.Count; i++)
        //    if (BodyAreas[i].isBrain)
        //    {
        //        BodyAreas.RemoveAt(i);
        //        break;
        //    }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameTimer <= GameDuration)
        {
            GameTimer += Time.deltaTime;
            float remaining = GameDuration - GameTimer;
            float min = Mathf.Floor(remaining / 60);
            float sec = Mathf.RoundToInt(remaining % 60);

            string minutes = min.ToString();
            string seconds = Mathf.RoundToInt(sec).ToString();
            if (min < 10)
                minutes = "0" + min.ToString();
            if (sec < 10)
                seconds = "0" + Mathf.RoundToInt(sec).ToString();

            timerText.text = minutes + ":" + seconds;
        }
        else
        {
            gameComplete = true;
            Debug.Log("You Beat The Game");
        }

        if (!gameComplete)
        {

            if (PlayerLives > 0)
            {

                if (runInterval && activeEvents.Count < maxEvents)
                {
                    if (intervalTimer >= intervalPeriod)
                    {
                        if (activeEvents.Count <= maxEvents)
                            CreateEvent();
                        SetIntervalTime();
                    }
                    else
                        intervalTimer += Time.deltaTime;
                }
            }
            else
            {
                if (!gameOver)
                {
                    Debug.Log("Player Out of Lives");
                    gameOver = true;
                }
            }
        }
    }

    void SetIntervalTime()
    {
        float DifficultyPercent = GameTimer / GameDuration;
        int diffIndex = (int)data.intervalCurve.Evaluate(DifficultyPercent);

        intervalPeriod = Random.Range(data.IntervalDifficulty[diffIndex].minInterval, data.IntervalDifficulty[diffIndex].maxInterval);
        intervalTimer = 0;
        runInterval = true;
    }

    void CreateEvent()
    {
        int type = Random.Range(0, eventPrefabs.Length);
        //List<NavigationPoint> possiblePoints = BodyAreas;
        //for (int i = activeEvents.Count - 1; i >= 0; i--)
        //{
        //    possiblePoints.Remove(activeEvents[i].eventPoint);
        //}
        List<NavigationPoint> possiblePoints = new List<NavigationPoint>();
        for (int i = 0; i < BodyAreas.Count; i++)
        {
            bool canAdd = true;

            for (int j = 0; j < activeEvents.Count; j++)
            {
                if (BodyAreas[i] == activeEvents[j].eventPoint)
                {
                    canAdd = false;
                    break;
                }
            }

            if (canAdd)
                possiblePoints.Add(BodyAreas[i]);
        }
        NavigationPoint eventPoint = possiblePoints[Random.Range(0, possiblePoints.Count)];



        GameObject eventInstance = Instantiate(eventPrefabs[type], eventPoint.eventRoot.transform);
        BodyEvent instanceEvent = eventInstance.GetComponent<BodyEvent>();

        float DifficultyPercent = GameTimer / GameDuration;
        int reachIndex = (int)data.intervalCurve.Evaluate(DifficultyPercent);
        float reachTime = Random.Range(data.IntervalDifficulty[reachIndex].timeToReach.x, data.IntervalDifficulty[reachIndex].timeToReach.x);


        instanceEvent.CreateEvent(this, eventPoint, reachTime, DifficultyPercent);
        activeEvents.Add(instanceEvent);

        Debug.Log("Event Created at: " + eventPoint.name);
    }

    public void EventCompleted(BodyEvent bodyEvent)
    {
        activeEvents.Remove(bodyEvent);
        //bodyEvent.GetComponentsInChildren<Animator>().SetBool("Done", true);
        Animator[] anim = bodyEvent.GetComponentsInChildren<Animator>();
        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetBool("Done", true);
        }
        Destroy(bodyEvent.gameObject, 0.4f);
    }

    public void EventFailed(BodyEvent bodyEvent)
    {
        PlayerLives--;
        LifeSlider.value = PlayerLives;
        activeEvents.Remove(bodyEvent);
        // bodyEvent.GetComponentsInChildren<Animator>().SetBool("Done", true);
        Animator[] anim = bodyEvent.GetComponentsInChildren<Animator>();
        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetBool("Done", true);
        }
        Destroy(bodyEvent.gameObject, 0.4f);
    }
}
