using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MazeTimer : MonoBehaviour
{
    float currentTime;
    public float startingTime = 10f;
    bool running;

    InstantiateMaze manager;

    public void SetManager(InstantiateMaze manager)
    {
        this.manager = manager;
    }

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
                manager.Failed();
                Debug.Log("System Failure");
            }
        }
    }

    public void SetValues(float time)
    {
        currentTime = time;
    }

    public void StartTimer()
    {
        running = true;
    }
}