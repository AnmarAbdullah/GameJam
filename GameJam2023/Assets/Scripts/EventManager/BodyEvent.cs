using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class BodyEvent : MonoBehaviour
{

    EventManager manager;
    Navigation nav;
    NavigationPoint eventPoint;
    float TimeToReachEvent;
    float reachTimer;
    bool reachTime;
    public Slider timeSlider;

    GameObject PanelRoot;
    [SerializeField] GameObject NotiPrefab;
    GameObject notification;

    // Start is called before the first frame update
    void Awake()
    {
        PanelRoot = GameObject.FindGameObjectWithTag("Panel");
    }

    // Update is called once per frame
    void Update()
    {
        if (reachTime)
        {
            if (reachTimer >= TimeToReachEvent)
            {
                //Took Too Long to get there
                Debug.Log("Took Too Long To Reach Point;");
                reachTime = false;
                Failed();   
            }
            else
            {
                reachTimer += Time.deltaTime;
                timeSlider.value = TimeToReachEvent - reachTimer;
            }
        }
    }

    public virtual void CreateEvent(EventManager eManager, NavigationPoint point, float timeToReach)
    {
        manager = eManager;
        eventPoint = point;
        
        notification = Instantiate(NotiPrefab, PanelRoot.transform);
        notification.transform.parent = PanelRoot.transform;
        notification.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = $"Location: {point.name}";
        notification.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = $"Problem: You have cancer...";

        Slider slider = notification.transform.GetChild(2).GetComponent<Slider>();
        slider.maxValue = timeToReach;
        slider.value = timeToReach;
        timeSlider = slider;

        TimeToReachEvent = timeToReach;
        reachTimer = 0;
        reachTime = true;
    }



    public virtual void StartEvent()
    {
        reachTime = false;
        Debug.Log("Player Started Event");
    }

    public void Completed()
    {
        Destroy(notification);
        manager.EventCompleted(this);
    }

    public void Failed()
    {
        Destroy(notification);
        manager.EventFailed(this);
    }
}
