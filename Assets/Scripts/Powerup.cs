using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{

    //Setup runs when the ball is fired
    public abstract void setup();

    //Stop and clean up any unfinished tasks (when ball is disabled)
    //Avoids race conditions
    public abstract void stop();

    //Name of the powerup
    public abstract string powerupName { get; }

}
