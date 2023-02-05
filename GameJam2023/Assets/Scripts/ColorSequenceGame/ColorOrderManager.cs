using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorOrderManager : MonoBehaviour
{
    public Image[] images;
    public int[] arrayOfNums = { 0, 1, 2, 3, 4, 5, 6, 7 };

    Dictionary<string, Color> colours;
    public Color colorToPick;

    public int score;
    public TextMeshProUGUI pickTxt;
    public TextMeshProUGUI scoreTxt;

    int sequenceCount;
    float duration;
    ColorSequenceTimer timer;

    bool running;
    BodyEvent_ColorOrder ev;
    public GameObject toggleObject;

    public void SetUp(int count, float timer)
    {
        sequenceCount = count;
        duration = timer;
        running = false;

        toggleObject.SetActive(false);

        colours = new Dictionary<string, Color>();
        colours.Add("blue", Color.blue);
        colours.Add("Cyan", Color.cyan);
        colours.Add("Gray", Color.gray);
        colours.Add("Green", Color.green);
        colours.Add("Red", Color.red);
        colours.Add("Magenta", Color.magenta);
        colours.Add("White", Color.white);
        colours.Add("Yellow", Color.yellow);
    }

    public void StartGame()
    {
        running = true;
        toggleObject.SetActive(true);

        images = GetComponentsInChildren<Image>();
        setupColours();
        setupText();

        timer.StartTimer(duration, ev);
    }

    void Awake()
    {
        ev = GetComponent<BodyEvent_ColorOrder>();
    }

    public void setupColours()
    {
        images = GetComponentsInChildren<Image>();
        // shuffles the array randomly
        arrayOfNums = arrayOfNums.OrderBy(i => Random.Range(0, images.Length)).ToArray();

        int newNum = 0;
        foreach (Image img in images)
        {
            img.color = setColour(arrayOfNums[newNum]);
            newNum++;
        }
    }

    public void setupText()
    {
        int rand = Random.Range(0, colours.Count);
        pickTxt.text = "Click " + colours.ElementAt(rand).Key;
        colorToPick = colours.ElementAt(rand).Value;
        pickTxt.color = setColour(Random.Range(0, 7));
        scoreTxt.text = "Score: " + score;

        if (score >= 4)
        {
            // Logic Here
            Debug.Log("Game Won");
        }
    }


    public Color setColour(int numInArray)
    {
        switch (numInArray)
        {
            case 0:
                return Color.blue;
            case 1:
                return Color.cyan;
            case 2:
                return Color.gray;
            case 3:
                return Color.green;
            case 4:
                return Color.magenta;
            case 5:
                return Color.red;
            case 6:
                return Color.white;
            case 7:
                return Color.yellow;
            default:
                return Color.clear;
        }
    }

    public void checkColour(Image image)
    {
        if (running)
        {
            if (image.color == colorToPick)
            {
                setupColours();
                setupText();
                score++;
                if (score > sequenceCount)
                    ev.Completed();
                scoreTxt.text = "Score: " + score;
            }
            else
            {
                ev.Failed();
            }
        }
    }
}