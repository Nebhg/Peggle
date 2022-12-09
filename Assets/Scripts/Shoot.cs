using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Shoot : MonoBehaviour
{
    public static int ammo {get; set;}
    public float LaunchForce;
    public GameObject Pinball;

    public delegate void ShootAction();
    public static event ShootAction OnShoot;
    public AudioClip ShootSound; 

    public static bool canFire {get; set;}

    // Start is called before the first frame update
    void Start()
    {
        ammo = 10;
        canFire = true;
        OnShoot();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Fire();
        }
       
    }

    void Fire()
    {
        if(ammo > 0 && canFire && !MenuController.GameIsPaused)
        {
            
            //GameObject PinballIns = Instantiate(Pinball,transform.position,transform.rotation);
            GameObject PinballIns = GameController.BallNext(transform.position, transform.rotation, true);
            PinballIns.GetComponent<Rigidbody2D>().velocity = -transform.up * LaunchForce;
            

            ammo--;

            canFire = false;
            AudioSource.PlayClipAtPoint(ShootSound, new Vector3(transform.position.x, transform.position.y, -10));
            OnShoot();
        }
        Debug.Log("You have " + ammo + " remaining!");
        //.AddForce(transform.up * LaunchForce);
        UiController.updatePowerupText();
    }

}
