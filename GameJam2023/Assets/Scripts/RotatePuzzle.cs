using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotatePuzzle : MonoBehaviour
{
    public List<GameObject> objectsToToggle;

    [SerializeField] GameObject Rotater;
    [SerializeField] Transform Goal;
    [SerializeField] bool eventStarted;
    [SerializeField] bool onGoal;
    [SerializeField] int speed;
    [SerializeField] private Transform arrow; 
    [SerializeField] float duration;
    [SerializeField] GameObject Center;

    [SerializeField] int amountOfSpawns;
    [SerializeField] Slider slider;

    BodyEvent_Rotater ev;

    private void Awake()
    {
        ev = GetComponent<BodyEvent_Rotater>();
    }

    public void StartEvent()
    {
        for (int i = 0; i < objectsToToggle.Count; i++)
            objectsToToggle[i].SetActive(true);

        eventStarted = true;
        slider.gameObject.SetActive(true);
        slider.maxValue = duration;
    }

    private void Update()
    {
        if (eventStarted)
        {
            duration -= Time.deltaTime;
            slider.value = duration;
            if(duration <= 0)
            {
                // Activate Loss Event
                eventStarted = false;
            }
            Rotater.transform.RotateAround(Center.transform.position, Vector3.back, speed * Time.deltaTime);


            Vector3 dirFromAtoB = (Center.transform.position - Rotater.transform.position).normalized;
            float dotProd = Vector3.Dot(arrow.up, Center.transform.forward);

            Debug.Log(dotProd);
            if (dotProd >0.97f)
            {
                Debug.Log("On Goal");
                onGoal = true;
                if (onGoal)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        // Activate Win Event
                        ev.Completed();
                        eventStarted = false;
                    }
                }
            }
            else onGoal = false;
            
            if (!onGoal & Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("You Lost Dumboo");
                // Activate loss event
                ev.Failed();
                eventStarted = false;
            }
        }
    }

    void CreateElement()
    {
        Vector3 spawnPos = (Center.transform.forward * 1f) + Center.transform.position;
        Transform gb = Instantiate(Goal, spawnPos,transform.rotation);
        gb.SetParent(transform);
        gb.transform.LookAt(Center.transform.position);
        objectsToToggle.Add(gb.gameObject);
        Vector3 dirFromAtoB = (Center.transform.position - Rotater.transform.position).normalized;
        float dotProd = Vector3.Dot(dirFromAtoB, transform.forward);
    }

    public void SetUp(int s, float dur)
    {
        Center.transform.rotation = Quaternion.Euler(Random.Range(1, 360), 90, 0);
        //Rotater.SetActive(false);
        speed = s;
        duration = dur;
        CreateElement();

        for (int i = 0; i< objectsToToggle.Count; i++)
            objectsToToggle[i].SetActive(false);
    }
}
