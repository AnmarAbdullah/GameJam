using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class RandomMaze : MonoBehaviour
{

    //  public Transform pos;

    public GameObject[] instantiatemazepath;

    float distance = 10;

    float currentTime;
    public float startingTime = 10f;
    bool running;
    [SerializeField] TextMeshProUGUI countdownText;

    void Start()
    {
        InstantiateMazePath();
    }

    private void Update()
    {
        MazeTimer();
    }

    void MazeTimer()
    {
        if (running)
        {

            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                currentTime = 0;
                // Your Code Here
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

    private void InstantiateMazePath()
    {
        int n = Random.Range(0, instantiatemazepath.Length);
        Instantiate(instantiatemazepath[n], this.transform);

        Debug.Log("Spawned Maze Path");
    }

    

    void MazeFail()
    {
        Debug.Log("You lost the maze");
        // call event manager fail function
    }

    void MazeSuccess()
    {
        Debug.Log("You won the maze");
        // bool to check if player won or not
        // call event manager success function
    }

    /* void OnTriggerEnter(Collider other)
     {
         Debug.Log("MazeActivityComplete");
     }*/

}
