using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBombPlacement : MonoBehaviour
{

    public GameObject bombPrefab;
	
	// Update is called once per frame
	void Update () 
    {
		if (Input.GetMouseButtonDown(0))
        {
            //The mouse position in pixels (for X and Y), but with a value of 10 offset in Z
            Vector3 mousePositionWithZOffset = Input.mousePosition;
            mousePositionWithZOffset.z = 10;

            //Where the camera is viewing from
            Vector3 cameraPosition = Camera.main.transform.position;

            //Get the position 10 units away from the mouse click down the camera frustrum
            Vector3 mousePositionInWorldSpace = Camera.main.ScreenToWorldPoint(mousePositionWithZOffset);

            //The vector different from the camera, to the mouse click position down the frustrum
            //It effectively gets the direction of the mouse click going throught the camera frustrum
            Vector3 directionFromCameraToMouse = mousePositionInWorldSpace - cameraPosition;

            //We have hit a collider, now the 'hitInfo' has been populated for us
            RaycastHit hitInfo;
            if (Physics.Raycast(new Ray(cameraPosition, directionFromCameraToMouse), out hitInfo, Mathf.Infinity))
            {
             
                //Create a bomb
                GameObject bombInstance = Instantiate(bombPrefab);
                //Parent it to whatever we hit
                bombInstance.transform.parent = hitInfo.collider.transform;

                //Set it's position to be exact point we hit
                bombInstance.transform.position = hitInfo.point;

                //This deals with scaling and item rotation
                // Quaternion.identity is 0,0,0 ROTATION
                bombInstance.transform.localRotation = Quaternion.identity;

                //Set local SCALE to 1,1,1
                bombInstance.transform.localScale = Vector3.one;

                //Get it's estimated true scale - If the parents scale was 2 and local scale was 1 the true scale would be 1 / 2 or 0.5 to compensate for parents scale. 
                Vector3 trueScale = bombInstance.transform.lossyScale;

                bombInstance.transform.localScale = new Vector3(1 / trueScale.x, 1 / trueScale.y, 1 / trueScale.z);
                //Now light the fuse
                bombInstance.GetComponent<Bomb>().LightFuse();
            }
        }
	}
}
