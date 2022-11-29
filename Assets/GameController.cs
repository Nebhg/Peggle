using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    private static int score;

    //Pooling on the pinballs
    private const int ballPoolSize = 2;
    public static GameObject[] ballPool;

    [SerializeField]
    private GameObject ballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        ballPool = new GameObject[ballPoolSize];

        for(int i = 0; i < ballPoolSize; i++){
            ballPool[i] = Instantiate(ballPrefab);
            ballPool[i].SetActive(false);
            ballPool[i].GetComponent<Ball>().id = i;
            
        }
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
    
    public enum LossReason {OutOfAmmo}

    public static void GameLose(LossReason reason)
    {
        Debug.Log("You have lost!");
        SceneManager.LoadScene(0);
    }

    public static void GameWin()
    {
        Debug.Log("You have won!");
        SceneManager.LoadScene(0);
    }

    public static void BallDeactivate(int id){
        ballPool[id].GetComponent<TrailRenderer>().Clear();
        ballPool[id].SetActive(false);
    }

    public static GameObject BallNext(Vector3 position, Quaternion rotation){
        for(int i = 0; i < ballPoolSize; i++){
            Debug.Log("Checking ball " + i);
            if(!ballPool[i].activeSelf){
                ballPool[i].transform.position = position;
                ballPool[i].transform.rotation = rotation;
                ballPool[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;              
                ballPool[i].SetActive(true);
                ballPool[i].GetComponent<Ball>().activate();
                return ballPool[i];
            }
        }
        Debug.Log("No balls available");
        return null;
    }
}
