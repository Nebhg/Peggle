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


    public enum Type {None, NoGravity, Splitball};

    public static Dictionary<Type, string> powerupNameMap {get;} = new Dictionary<Type, string>()
    {
        {Type.None, "None"},
        {Type.NoGravity, "No Gravity"},
        {Type.Splitball, "Split Ball"}
    };

    public abstract Type type { get; }

}
