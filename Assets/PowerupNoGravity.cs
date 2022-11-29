using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupNoGravity : MonoBehaviour, Powerup
{


    const float time = 2f;

    float initialScale;
    GameObject ball;

    public static string name = "No Gravity";

     
    public void setup(GameObject ball)
    {
        this.ball = ball;

        //Disable gravity
        initialScale = ball.GetComponent<Rigidbody2D>().gravityScale;
        ball.GetComponent<Rigidbody2D>().gravityScale = 0f;

        //Switch gravity back on after a few seconds
        StartCoroutine(delayedNormalGravity());

    }


    public void stop(){
        //Stop the coroutine
        StopCoroutine(delayedNormalGravity());
    }

    IEnumerator delayedNormalGravity(){
        //Wait for a certain amount of time
        yield return new WaitForSeconds(time);
        //Set gravity back to normal
        this.ball.GetComponent<Rigidbody2D>().gravityScale = initialScale;
    }
}