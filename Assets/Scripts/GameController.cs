using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    private static int score;

    public enum GameState {Playing, Win, Loss};
    private static GameState gameSate = GameState.Playing;

    //Pooling on the pinballs
    public const int ballPoolSize = 2;
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

    public static int ResetScore()
    {
        score = 0;
        return score;
    }

    public static void GameLose(LossReason reason)
    {
        gameSate = GameState.Loss;
        ResetScore();
        cleanupAfterLevel();
    }

    public static void GameWin()
    {
        gameSate = GameState.Win;
        ResetScore();
        cleanupAfterLevel();
    }

    public static void BallDeactivate(int id){
        ballPool[id].GetComponent<TrailRenderer>().Clear();
        ballPool[id].SetActive(false);
    }

    public static void cleanupAfterLevel(){
        Ball.nextPowerups.Clear();
    }

    public static GameObject BallNext(Vector3 position, Quaternion rotation, bool setPowerup = false){
        for(int i = 0; i < ballPoolSize; i++){
            Debug.Log("Checking ball " + i);
            if(!ballPool[i].activeSelf){
                ballPool[i].transform.position = position;
                ballPool[i].transform.rotation = rotation;
                ballPool[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;              
                ballPool[i].SetActive(true);
                if(setPowerup) ballPool[i].GetComponent<Ball>().nextPowerup();      
                ballPool[i].GetComponent<Ball>().activate();
                return ballPool[i];
            }
        }
        Debug.Log("No balls available");
        return null;
    }

    public static int AvailableBalls(){
        int count = 0;
        for(int i = 0; i < ballPoolSize; i++){
            if(!ballPool[i].activeSelf){
                count++;
            }
        }
        return count;
    }

    public static void UpdateGameState(GameState newState){
        gameSate = newState;
    }

    public static GameState GetGameState(){
        return gameSate;
    }
}
