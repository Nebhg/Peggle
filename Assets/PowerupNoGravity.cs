using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupNoGravity : MonoBehaviour, Powerup
{


    const float time = 2f;

    float initialScale;

    public static string powerupName = "No Gravity";

    private GameObject effectLowG;

     
    public void setup()
    {

        effectLowG = gameObject.transform.Find("EffectLowG").gameObject;
        effectLowG.SetActive(true);

        //Disable gravity
        initialScale = gameObject.GetComponent<Rigidbody2D>().gravityScale;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;

        //Switch gravity back on after a few seconds
        StartCoroutine(delayedNormalGravity());

    }


    public void stop(){
        //Stop the coroutine
        StopCoroutine(delayedNormalGravity());
        normalGravity();
    }

    IEnumerator delayedNormalGravity(){
        //Wait for a certain amount of time
        yield return new WaitForSeconds(time);
        //Set gravity back to normal
        normalGravity();
    }

    private void normalGravity(){
        gameObject.GetComponent<Rigidbody2D>().gravityScale = initialScale;
        effectLowG.SetActive(false);
    }
}