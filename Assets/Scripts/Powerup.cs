using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Powerup
{

    //Setup runs when the ball is fired
    public void setup();

    //Stop and clean up any unfinished tasks (when ball is disabled)
    //Avoids race conditions
    public void stop();

    //Name of the powerup
    public static string name;

}
