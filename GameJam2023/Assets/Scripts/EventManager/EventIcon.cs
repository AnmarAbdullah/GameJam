using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class EventIcon : MonoBehaviour
{
    Image icon;

    public AnimationCurve flashCurve;
    public AnimationCurve SpeedCurve;
    public Color flashColor;
    public Gradient baseColorRange;
    public Gradient currentColorRange;

    Color currentColor;
    float currentSpeed;
    BodyEvent connectedEvent;

    float flashtimer;
    public float timeToReach;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        currentColor = baseColorRange.Evaluate(0);
        currentSpeed = SpeedCurve.Evaluate(0);
        timer = 0;
        flashtimer = 0;

        icon = GetComponent<Image>();
        icon.color = currentColor;
    }

    // Update is called once per frame
    void Update()
    {
        currentColor = baseColorRange.Evaluate(timer / timeToReach);

        currentColorRange = new Gradient();
        GradientColorKey[] Colors = { new GradientColorKey(currentColor, 0), new GradientColorKey(flashColor, 1) };
        GradientAlphaKey[] Aplhas = { new GradientAlphaKey(1, 0), new GradientAlphaKey(1, 1) };
        currentColorRange.SetKeys(Colors, Aplhas);
        

        icon.color = currentColorRange.Evaluate(flashtimer / currentSpeed);

        if (timer <= timeToReach)
        {
            timer += Time.deltaTime;
            flashtimer += Time.deltaTime;

            if (flashtimer >= currentSpeed)
            {
                flashtimer = 0;
                currentSpeed = SpeedCurve.Evaluate(timer / timeToReach);
            }
        }
    }
}
