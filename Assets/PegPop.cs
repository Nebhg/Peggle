using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegPop : MonoBehaviour
{
    public static int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        points += 10;
        //Debug.Log("popped! Total Points: " + points);
        gameObject.SetActive(false);
        if(points >= 250)
        {
            Debug.Log("You have won!");
        }
        
    }
}
