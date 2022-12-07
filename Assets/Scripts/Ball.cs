using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Shoot shooter {get; set;}

    public Powerup powerup;

    public static Queue<Powerup> nextPowerups = new Queue<Powerup>();
    public int id {get; set;}



    [SerializeField] private Powerup[] powerups;

    // Awake runs before OnEnable (Start runs after OnEnable)
    void Awake()
    {

      this.powerup = powerups[2];
        
    }

    public void activate(){
        
        this.powerup.setup();        
        StartCoroutine(checkHeight());

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
        Shoot.canFire = true;
        this.powerup.stop();
        GameController.BallDeactivate(id);
        if(Shoot.ammo <= 0){
            GameController.GameLose(GameController.LossReason.OutOfAmmo);
        }

    }

    public static void randomPowerup(){

    }


}
