using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegSelector : MonoBehaviour
{

    public static List<GameObject> pegs;
    public static List<GameObject> targets;
    public static int targetCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        pegs = new List<GameObject>(GameObject.FindGameObjectsWithTag("peg"));
        Debug.Log(pegs.Count);
        int requiredTargets = (int)(pegs.Count * 0.1f);

        //randomly assign targets
        //targets = new List<GameObject>();

/*
        for(int i = 0; i<requiredTargets; i++){
            int index = Random.Range(0,pegs.Count);
            //targets.Add(pegs[index]);
            
            pegs[index].GetComponent<PegPop>().changeToTarget();

            pegs.RemoveAt(index);
        }
*/
        //targetCount = targets.Count;
        
        setManyPegTypes(PegType.Powerup, 1);
        setManyPegTypes(PegType.Target, requiredTargets);
        
    }

    public enum PegType { Target, NonTarget, Powerup };

    

    void setPegType(PegType type){
        int index = Random.Range(0,pegs.Count);

        switch(type){
            case PegType.Target:
                pegs[index].GetComponent<PegPop>().changeToTarget();
                targetCount++;
                break;
            case PegType.Powerup:
                pegs[index].GetComponent<PegPop>().changeToPowerup();
                break;
            case PegType.NonTarget:
                break;
        }

        pegs.RemoveAt(index);
    }

    void setManyPegTypes(PegType type, int count){
        for(int i = 0; i<count; i++){
            setPegType(type);
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
