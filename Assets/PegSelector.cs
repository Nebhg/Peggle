using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegSelector : MonoBehaviour
{

    List<GameObject> pegs;

    // Start is called before the first frame update
    void Start()
    {
        pegs = new List<GameObject>(GameObject.FindGameObjectsWithTag("peg"));
        Debug.Log(pegs.Count);
        int requiredTargets = (int)(pegs.Count * 0.25f);

        //randomly assign targets
        List<GameObject> targets = new List<GameObject>();

        for(int i = 0; i<requiredTargets; i++){
            int index = Random.Range(0,pegs.Count);
            targets.Add(pegs[index]);
            
            pegs[index].GetComponent<PegPop>().changeToTarget();

            pegs.RemoveAt(index);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
