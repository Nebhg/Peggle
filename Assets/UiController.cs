using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiController : MonoBehaviour
{


    [SerializeField]
    private TextMeshProUGUI ammoText;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable() {
        Shoot.OnShoot += updateAmmo;
    }

    private void OnDisable() {
        Shoot.OnShoot -= updateAmmo;
    }

    void updateAmmo(){
        ammoText.text = Shoot.ammo.ToString();
    }
}
