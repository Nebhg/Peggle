using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PegPop : MonoBehaviour
{
    public static int points = 0;
    public PegSelector.PegType type = PegSelector.PegType.NonTarget;

    public delegate void PointAquired();
    public static event PointAquired OnPop;

    public AudioClip PopSound;

    [SerializeField]
    private Material targetMaterial;

    [SerializeField]
    private Material nonTargetMaterial;

    [SerializeField]
    private Material powerupMaterial;

    public static bool hasWon = false;

    // Start is called before the first frame update
    void Start()
    {
        OnPop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        AudioSource.PlayClipAtPoint(PopSound, new Vector3(transform.position.x, transform.position.y, -10));
        GameController.AddScore(10);
        Debug.Log("Pegs " + PegSelector.targetCount);

        OnPop();
        //Debug.Log("popped! Total Points: " + points);
        PegSelector.targetCount -= type == PegSelector.PegType.Target ? 1 : 0;
        if(PegSelector.targetCount == 0)
        {
            hasWon = true;
            GameController.GameWin();
        }

        gameObject.SetActive(false);
        Debug.Log(PegSelector.targetCount + " targets left");
        
        
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
