using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(PauseMenu.GameIsPaused == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //get point on plane y=0
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 CannonPos = transform.position;
            direction = MousePos - CannonPos; //calculate direction
            FaceMouse();
        }
        
    }

    void FaceMouse()
    {
        transform.up = direction;
        
        /*
        gameObject.transform.rotation =
        gameObject.transform.rotation.eulerAngles.z > 90 ?
        Quaternion.Euler(0, 0, 90) :
        gameObject.transform.rotation.eulerAngles.z < -90 ?
        Quaternion.Euler(0, 0, -90) :
        gameObject.transform.rotation;
        */

        gameObject.transform.rotation = 
        Quaternion.Euler(0,0,Mathf.Clamp(gameObject.transform.rotation.eulerAngles.z - 180, -85, 85));
    }
}
