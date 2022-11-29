using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Shoot shooter {get; set;}

    private Powerup powerup;

    // Start is called before the first frame update
    void Start()
    {
        this.powerup = new PowerupNone();

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
        shooter.canFire = true;
        Destroy(gameObject);
        if(Shoot.ammo <= 0){
            GameController.GameLose(GameController.LossReason.OutOfAmmo);
        }

    }


}
