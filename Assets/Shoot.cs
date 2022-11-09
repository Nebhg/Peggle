using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public int ammo;
    public float LaunchForce;
    public GameObject Pinball;

    // Start is called before the first frame update
    void Start()
    {
        ammo = 10;
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
        if(ammo > 0)
        {
            GameObject PinballIns = Instantiate(Pinball,transform.position,transform.rotation);
            PinballIns.GetComponent<Rigidbody2D>().velocity = transform.up * LaunchForce;
            ammo--;
        }
        Debug.Log("You have " + ammo + " remaining!");
        //.AddForce(transform.up * LaunchForce);
    }

}
