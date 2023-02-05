using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class BodyEvent : MonoBehaviour
{
    public BodyEventDifficultyData data;
    EventManager manager;
    Navigation nav;
    public NavigationPoint eventPoint { get; private set; }
    float TimeToReachEvent;
    float reachTimer;
    bool reachTime;
    public Slider timeSlider;
    Animation anim;

    public GameObject IconRoot;
    public GameObject IconPrefab;
    GameObject Icon;
    GameObject PanelRoot;
    [SerializeField] GameObject NotiPrefab;
    GameObject notification;


    [SerializeField] Texture heartUI;
    [SerializeField] Texture lungsUI;
    [SerializeField] Texture StomachUI;

    // Start is called before the first frame update
    void Awake()
    {
        PanelRoot = GameObject.FindGameObjectWithTag("Panel");
        IconRoot = GameObject.FindGameObjectWithTag("IconRoot");
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
                if(timeSlider.value <= timeSlider.maxValue / 2)
                {
                    anim.Play();
                }
            }
        }
    }

    public virtual void CreateEvent(EventManager eManager, NavigationPoint point, float timeToReach, float diffPrecent)
    {
        manager = eManager;
        eventPoint = point;
        
        notification = Instantiate(NotiPrefab, PanelRoot.transform);
        notification.transform.parent = PanelRoot.transform;
        notification.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = $"{point.name}";
        notification.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = $"Signs Of Distress";

        Icon = Instantiate(IconPrefab, IconRoot.transform);
        Icon.GetComponent<EventIcon>().SetupIcon(this, timeToReach);


        Slider slider = notification.transform.GetChild(2).GetComponent<Slider>();
        slider.maxValue = timeToReach;
        slider.value = timeToReach;
        timeSlider = slider;


        RawImage target = notification.transform.GetChild(3).GetComponent<RawImage>();
        
        switch (point.name)
        {
            case "Heart":
                target.texture = heartUI;
            break;

            case "Lungs":
                target.texture = lungsUI;
                break;

            case "Stomach":
                target.texture = StomachUI;
                break;
        }
        
        Animation anima = notification.GetComponentInChildren<Animation>();
        anim = anima;

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
        Destroy(Icon);
        manager.EventCompleted(this);
    }

    public void Failed()
    {
        Destroy(notification);
        Destroy(Icon);
        manager.EventFailed(this);
    }
}
