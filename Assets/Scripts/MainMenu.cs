using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // used to move between scenes 

public class MainMenu : MonoBehaviour
{
    public string startScene;
    //public Animator transition;

    public void StartGame()
    {
        //transition.SetTrigger("Start");
        SceneManager.LoadScene(startScene);
    }

    public void QuitGame()
    {
        // only works when you build the game
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
