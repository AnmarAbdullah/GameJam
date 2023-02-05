using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource selectSound;
    public GameObject mainMenu;
    public GameObject difficultyMenu;
    public GameObject settingsMenu;
    public float delayscene = 0.1f;
    public Scene difficultyscene;

    public void PlayGame()
    {
        mainMenu.SetActive(false);
        difficultyMenu.SetActive(true);
        selectSound.Play();
    }

    public void BackPlayGame()
    {
        mainMenu.SetActive(true);
        difficultyMenu.SetActive(false);
        settingsMenu.SetActive(false);
        selectSound.Play();
    }

    public void SettingPage()
    {
        mainMenu.SetActive(false);
        difficultyMenu.SetActive(false);
        settingsMenu.SetActive(true);
        selectSound.Play();
    }

    public void LoadGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitted");
    }
}
