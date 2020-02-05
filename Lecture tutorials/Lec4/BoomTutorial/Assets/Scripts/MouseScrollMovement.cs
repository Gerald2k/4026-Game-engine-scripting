using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScrollMovement : MonoBehaviour {

	// Update is called once per frame
	void Update () 
    {
        //Sets the position to be the same, but addes more to the Z position
        //The mouse scroll delta, is the difference in the scrollwheel value
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + Input.mouseScrollDelta.y);
	}
}
