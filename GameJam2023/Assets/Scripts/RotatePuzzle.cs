using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePuzzle : MonoBehaviour
{
    [SerializeField] GameObject Rotater;
    [SerializeField] Transform Goal;
    [SerializeField] bool eventStarted;
    [SerializeField] bool onGoal;
    [SerializeField] int speed;

    [SerializeField] float duration;

    [SerializeField] int amountOfSpawns;
    private void Start()
    {
        transform.rotation = Quaternion.Euler(Random.Range(1,360), 90, 0);
        CreateElement();
        
    }


    private void Update()
    {
        if (eventStarted)
        {
            duration -= Time.deltaTime;
            if(duration <= 0)
            {
                // Activate Loss Event
                eventStarted = false;
            }
            Rotater.transform.RotateAround(transform.position, Vector3.back, speed * Time.deltaTime);


            Vector3 dirFromAtoB = (transform.position - Rotater.transform.position).normalized;
            float dotProd = Vector3.Dot(dirFromAtoB, transform.forward);
            // print(dotProd);

            if (dotProd < -0.9)
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
        Vector3 spawnPos = (transform.forward * 1f) + transform.position;
        Transform gb = Instantiate(Goal, spawnPos, Quaternion.identity);
        Vector3 dirFromAtoB = (transform.position - Rotater.transform.position).normalized;
        float dotProd = Vector3.Dot(dirFromAtoB, transform.forward);
    }
}
