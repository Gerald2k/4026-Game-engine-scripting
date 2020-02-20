using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftController : MonoBehaviour
{
    public GameObject liftObject;
    
    private bool liftUp;
    private bool buttonPressed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        buttonPressed = true;
    }

    private void OnMouseExit()
    {
        buttonPressed = false;
    }

    private void OnMouseDown()
    {
        liftUp = !liftUp;
        liftObject.GetComponent<Animator>().SetBool("liftIsUp", liftUp);
    }

    //This code checks whether the buttonPressed variable is true, if it is, it calls GUI.Box, with a new Rectangle and some text to put into it.
    //The rectangle uses some simple maths and some inbuilt unity classes to centre itself on screen for the player.
    private void OnGUI()
    {
        if (buttonPressed == true)
        {
            GUI.Box(
                new Rect(
                    Screen.width / 2 - 100,
                    Screen.height / 2 - 25,
                    200,
                    50),
                "Press Button"
                );
        }
    }
}
