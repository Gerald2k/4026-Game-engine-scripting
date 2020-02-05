using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	
	// Update is called once per frame
	void Update () 
    {
        //Gets Rotation
        Vector3 euler = transform.rotation.eulerAngles;
        //Adds the rotation x and y based on keyboard input
        euler.x += Input.GetAxis("Vertical");
        euler.y -= Input.GetAxis("Horizontal");
        
        //Assigns the rotation
        transform.rotation = Quaternion.Euler(euler);
    }
}
