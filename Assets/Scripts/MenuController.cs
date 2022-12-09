using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject loseMenuUI;
    public GameObject winMenuUI;
    // Update is called once per frame
    void Start()
    {
        Resume();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if(GameController.GetGameState() == GameController.GameState.Loss)
        {
            Lose();
        }
        else if(GameController.GetGameState() == GameController.GameState.Win)
        {
            Win();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        GameController.ResetScore();
        GameController.cleanupAfterLevel();
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void Lose()
    {
        loseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        GameController.UpdateGameState(GameController.GameState.Playing);
        GameController.ResetScore();
        GameController.cleanupAfterLevel();
        
    }

    public void Win()
    {
        winMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        GameController.UpdateGameState(GameController.GameState.Playing);
        GameController.ResetScore();
        GameController.cleanupAfterLevel();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        GameController.ResetScore();
        GameController.cleanupAfterLevel();
    }
    
    public void NextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            LoadMenu();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Time.timeScale = 1f;
            GameController.ResetScore();   
            GameController.cleanupAfterLevel();
            winMenuUI.SetActive(false); 
        }
        
    }
}
