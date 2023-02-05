using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorSequenceTimer : MonoBehaviour
{
    float currentTime;
    public float startingTime = 10f;
    bool running;

    BodyEvent_ColorOrder manager;

    [SerializeField] TextMeshProUGUI countdownText;
    void Start()
    {
        currentTime = startingTime;
    }
    void Update()
    {
        if (running)
        {

            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                currentTime = 0;
                Debug.Log("You lost the order of colors game");
                manager.Failed();
            }
        }
    }

    public void StartTimer(float duration, BodyEvent_ColorOrder man)
    {
        running = true;
        manager = man;
        currentTime = duration;
    }
}