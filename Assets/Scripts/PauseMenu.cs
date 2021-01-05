using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // used to move between scenes 

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public string levelSelect;
    public string mainMenu;

    public GameObject pauseScreen;
    public bool isPaused = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (isPaused)
        {
            isPaused = false;
            pauseScreen.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            isPaused = true;
            pauseScreen.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(levelSelect);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }
}
