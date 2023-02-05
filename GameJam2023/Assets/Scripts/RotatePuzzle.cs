using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotatePuzzle : MonoBehaviour
{
    [SerializeField] GameObject Rotater;
    [SerializeField] Transform Goal;
    [SerializeField] bool eventStarted;
    [SerializeField] bool onGoal;
    [SerializeField] float Speed;
    [SerializeField] private Transform arrow; 
    [SerializeField] float Duration;
    [SerializeField] GameObject Center;

    [SerializeField] int amountOfSpawns;
    [SerializeField] Slider slider;
    private void Start()
    {
        Center.transform.rotation = Quaternion.Euler(Random.Range(1,360), 90, 0);
        CreateElement();       
    }

    public void setValues(float duration, float speed)
    {
        Speed = speed;
        Duration = duration;
    }

    public void StartEvent()
    {
        eventStarted = true;
        slider.gameObject.SetActive(true);
        slider.maxValue = Duration;
    }

    private void Update()
    {
        if (eventStarted)
        {
            Duration -= Time.deltaTime;
            slider.value = Duration;
            if(Duration <= 0)
            {
                // Activate Loss Event
                eventStarted = false;
            }
            Rotater.transform.RotateAround(Center.transform.position, Vector3.back, Speed * Time.deltaTime);


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
                        eventStarted = false;
                    }
                }
            }
            else onGoal = false;
            
            if (!onGoal & Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("You Lost Dumboo");
                // Activate loss event
                eventStarted = false;
            }
        }
    }

    void CreateElement()
    {
        Vector3 spawnPos = (Center.transform.forward * 1f) + Center.transform.position;
        Transform gb = Instantiate(Goal, spawnPos,transform.rotation);
        gb.transform.LookAt(Center.transform.position);
        Vector3 dirFromAtoB = (Center.transform.position - Rotater.transform.position).normalized;
        float dotProd = Vector3.Dot(dirFromAtoB, transform.forward);
    }
}
