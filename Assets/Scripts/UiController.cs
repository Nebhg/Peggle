using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiController : MonoBehaviour
{


    [SerializeField]
    private TextMeshProUGUI ammoText;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI loseText;

    [SerializeField]
    private TextMeshProUGUI winText;

    [SerializeField]
    private TextMeshProUGUI powerupText;

    private static UiController mainInstance;

    // Start is called before the first frame update
    void Start()
    {
        mainInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnEnable() {
        Shoot.OnShoot += updateAmmo;
        PegPop.OnPop += updateScore;
    }

    private void OnDisable() {
        Shoot.OnShoot -= updateAmmo;
        PegPop.OnPop -= updateScore;
    }

    void updateAmmo(){
        ammoText.text = Shoot.ammo.ToString();
    }

    void updateScore(){
        scoreText.text = GameController.GetScore().ToString();
        loseText.text = GameController.GetScore().ToString();
        winText.text = GameController.GetScore().ToString();
    }

    public static void updatePowerupText(){ 
        string nextName = Powerup.powerupNameMap[Ball.getNextPowerup(false)];
        mainInstance.powerupText.text = "Next Powerup: " + nextName;
    }
}
