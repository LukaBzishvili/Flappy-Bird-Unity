using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public LogicScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!logic.checkIfGameIsOver()) { 
            if (Input.GetKeyDown(KeyCode.Escape)) {
                if (GameIsPaused)
                {
                    Resume();
                }
                else{
                    Pause();
                }
            }
        }
    }

    public void ResumeGame() {
        if (GameIsPaused) {
            Resume();
        }
    }

    public void QuitGame() {
        Debug.Log("Quitting Game...");
        Application.Quit();
    } 

    void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
