using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupNone : Powerup
{

    //Do nothing
    public override void setup(){
        Debug.Log("aaaa");
    }
    public override void stop(){}

    //Name of the powerup
    public override string powerupName {get;} = "None";

}
