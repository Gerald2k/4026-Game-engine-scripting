using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterScript : MonoBehaviour
{
    //This variable is initialised from the Unity editor and links to game text control.
    [SerializeField]
    private Text gameTextField;

    //This variable is initialised from the Unity editor and links to input control
    [SerializeField]
    private InputField inputTextField;

    //This variable tracks our gamestate.
    //1 = left first
    //2 = right first
    private int GameState = 0;
    public void EnterButtonClicked()
    {
        if (GameState == 0)
        {
            if(inputTextField.text.ToLower() == "left")
            {
                gameTextField.text = "The left hand side appears to lead to a small cottage, the right side a wall that lead into a field. Which way do you go?";
                GameState = 1;

            }
            if (inputTextField.text.ToLower() == "right")
            {
                gameTextField.text = "The left hand path leads to a dark cave. The right leads to sunlight. Which path do you choose?";
                GameState = 2;
            }
        }
        else if (GameState == 1)
        {
            if (inputTextField.text.ToLower() == "left")
            {
                gameTextField.text = "You die by spike";
                GameState = 3;
            }
            if (inputTextField.text.ToLower() == "right")
            {
                gameTextField.text = "You die by teddy bear";
                GameState = 4;
            }
        }
        else if (GameState == 2)
        {
            if (inputTextField.text.ToLower() == "left")
            {
                gameTextField.text = "You die by voodoo. Who do? You do.";
                GameState = 5;
            }
            if (inputTextField.text.ToLower() == "right")
            {
                gameTextField.text = "You die.";
                GameState = 6;
            }
        }
    }
   
}
