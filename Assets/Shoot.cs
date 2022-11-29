using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public static int ammo {get; set;}
    public float LaunchForce;
    public GameObject Pinball;

    public delegate void ShootAction();
    public static event ShootAction OnShoot;
   

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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
       
    }

    void Fire()
    {
        if(ammo > 0 && canFire)
        {
            
            //GameObject PinballIns = Instantiate(Pinball,transform.position,transform.rotation);
            GameObject PinballIns = GameController.BallNext(transform.position, transform.rotation);
            PinballIns.GetComponent<Rigidbody2D>().velocity = -transform.up * LaunchForce;
            

            ammo--;

            canFire = false;
            
            OnShoot();
        }
        Debug.Log("You have " + ammo + " remaining!");
        //.AddForce(transform.up * LaunchForce);
    }

}
