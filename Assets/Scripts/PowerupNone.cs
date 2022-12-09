using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupNone : Powerup
{

    public override Type type {get;} = Type.None;
    //Do nothing
    public override void setup(){
        Debug.Log("aaaa");
    }
    public override void stop(){}

    //Name of the powerup


}
