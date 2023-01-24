using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{

    Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        //Vector3 mousePos = Input.mousePosition;
        //mousePos.z = 10f;
        //mousePos = cam.ScreenToWorldPoint(mousePos);
        //Debug.DrawRay(transform.position, forwardmousePos - transform.position, Color.red);


   /*     RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit something");3

            if (hit.collider.tag == "Ghost")
            {
                print("Boo");
            }

            else
            {

                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            }
        }
   */
    }
}
