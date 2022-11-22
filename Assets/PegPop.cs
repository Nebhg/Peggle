using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegPop : MonoBehaviour
{
    public static int points = 0;
    public PegSelector.PegType type = PegSelector.PegType.NonTarget;

    [SerializeField]
    private Material targetMaterial;

    [SerializeField]
    private Material nonTargetMaterial;

    [SerializeField]
    private Material powerupMaterial;

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
        PegSelector.targetCount -= type == PegSelector.PegType.Target ? 1 : 0;
        if(PegSelector.targetCount <= 0)
        {
            GameController.GameWin();
        }
        
    }

    public void changeToTarget(){
        gameObject.GetComponent<SpriteRenderer>().material = targetMaterial;
        type = PegSelector.PegType.Target;
    }

    public void changeToPowerup(){
        gameObject.GetComponent<SpriteRenderer>().material = powerupMaterial;
        type = PegSelector.PegType.Powerup;
    }
}
