using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour 
{
    public string importantTag = "Important";
    private int importantCount = 0;

	void Update () 
    {
		if(importantCount == 0)
        {
            //WIN
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == importantTag)
        {
            importantCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == importantTag)
        {
            importantCount--;
        }
    }

    public void OnGUI()
    {
        //We are going to set the main colour for our text to be black
        GUI.color = Color.black;
        //Will list the remaining items to bomb offscreen
        GUI.Label(new Rect(0, 0, 200, 100), "Remaining: " + importantCount);

    }
}
