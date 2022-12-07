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
        if(MenuController.GameIsPaused == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //get point on plane y=0

            //Create a plane perpendicular to the z axis at the origin
            //This essentially serves as the new 2D "screen" in the 3D scene
            Plane plane = new Plane(Vector3.forward, Vector3.zero);

            //Raycast from the camera to the plane
            float distance;
            plane.Raycast(ray, out distance);

            //Get the intersection point
            Vector3 point = ray.GetPoint(distance);

            //Cast the point into 2D to work with 2D physics
            Vector2 MousePos = point;
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
