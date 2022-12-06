using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSplit : MonoBehaviour, Powerup
{

    //Do nothing
    public void setup(){
        StartCoroutine(delay());
    }
    public void stop(){
        StopAllCoroutines();
    }

    //Name of the powerup
    public static string powerupName = "Split Ball";

    IEnumerator delay(){
        yield return new WaitForSeconds(0.1f);
        GameObject newBall = GameController.BallNext(this.transform.position, this.transform.rotation);
    }

}
