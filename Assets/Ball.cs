using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Shoot shooter {get; set;}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 0){
            shooter.canFire = true;
            Destroy(gameObject);
            if(Shoot.ammo <= 0){
                Debug.Log("Out of ammo!");
                GameController.GameLose();
            }
        }
    }

}
