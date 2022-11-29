using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupNoGravity : MonoBehaviour, Powerup
{


    const float time = 2f;

    float initialScale;

    public static string name = "No Gravity";

     
    public void setup()
    {
        //Disable gravity
        initialScale = gameObject.GetComponent<Rigidbody2D>().gravityScale;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;

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
        gameObject.GetComponent<Rigidbody2D>().gravityScale = initialScale;
    }
}