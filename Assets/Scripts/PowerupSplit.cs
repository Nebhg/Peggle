using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSplit : Powerup
{

    //Do nothing
    public override void setup(){
        StartCoroutine(delay());
    }
    public override void stop(){
        StopAllCoroutines();
    }

    //Name of the powerup
    public override string powerupName {get;} = "Split Ball";

    IEnumerator delay(){
        yield return new WaitForSeconds(0.1f);
        GameObject newBall = GameController.BallNext(this.transform.position, this.transform.rotation);
        Rigidbody2D myRb = this.gameObject.GetComponent<Rigidbody2D>();
        Rigidbody2D newRb = newBall.GetComponent<Rigidbody2D>();
        newRb.velocity = -myRb.velocity;
    }

}
