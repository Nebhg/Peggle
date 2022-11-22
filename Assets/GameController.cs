using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    private static int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void AddScore(int points)
    {
        score += points;
    }

    public static int GetScore()
    {
        return score;
    }

    public static void GameLose()
    {
        Debug.Log("You have lost!");
        SceneManager.LoadScene(0);
    }

    public static void GameWin()
    {
        Debug.Log("You have won!");
        SceneManager.LoadScene(0);
    }
}
