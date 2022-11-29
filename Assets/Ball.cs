using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Shoot shooter {get; set;}

    private Powerup powerup;

    public int id {get; set;}

    // Awake runs before OnEnable (Start runs after OnEnable)
    void Start()
    {
        this.powerup = new PowerupNone();

        
    }

    public void activate(){
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
        GameController.BallDeactivate(id);
        if(Shoot.ammo <= 0){
            GameController.GameLose(GameController.LossReason.OutOfAmmo);
        }

    }


}
