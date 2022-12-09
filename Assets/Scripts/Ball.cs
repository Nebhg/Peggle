using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Shoot shooter {get; set;}

    public Powerup powerup;

    //Use a static queue because we want to share the same queue between all balls
    public static Queue<Powerup.Type> nextPowerups = new Queue<Powerup.Type>();
    public int id {get; set;}

    public static Powerup.Type[] powerupTypeMap = 
    {
        Powerup.Type.None, 
        Powerup.Type.NoGravity, 
        Powerup.Type.Splitball
    };

    [SerializeField] private Powerup[] powerups;

    // Awake runs before OnEnable (Start runs after OnEnable)
    void Awake()
    {

      this.powerup = powerups[0];
        
    }

    public void activate(){
        
        
        this.powerup.setup();        
        StartCoroutine(checkHeight());

    }

    public void nextPowerup(){
        this.powerup = powerupTypeToPowerup(getNextPowerup(true));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator checkHeight(){
        while(gameObject.transform.position.y > 0){
            yield return new WaitForSeconds(0.5f);
        }
        //Ball below y=0

        this.powerup.stop();
        GameController.BallDeactivate(id);

        Debug.Log("balls " + GameController.AvailableBalls());
        
        
        if(GameController.AvailableBalls() == GameController.ballPoolSize){
            Shoot.canFire = true;         
            if(Shoot.ammo <= 0){
                GameController.GameLose(GameController.LossReason.OutOfAmmo);
            }
        }

    }

    public static void enqueueRandomPowerup(){
        //Skip first (poerup none) powerup
        Powerup.Type randPowerup = powerupTypeMap[UnityEngine.Random.Range(1, powerupTypeMap.Length)];
        nextPowerups.Enqueue(randPowerup);
    }

    //Each ball has a local instance of the Powerup script attached to itself
    //So we need to map the static Powerup.Type to the local Powerup instance
    private Powerup powerupTypeToPowerup(Powerup.Type type){
        int index = Array.IndexOf(powerupTypeMap, type);
        return powerups[index];
    }

    public void setPowerup(Powerup.Type type){
        this.powerup = powerupTypeToPowerup(type);
    }

    public static Powerup.Type getNextPowerup(bool dequeue = false){
        Powerup.Type nextType;
        if(Ball.nextPowerups.Count == 0){
            nextType = Powerup.Type.None;
        }else{
            nextType = dequeue ? Ball.nextPowerups.Dequeue() : Ball.nextPowerups.Peek();
        }    
        return nextType;
    }


}
