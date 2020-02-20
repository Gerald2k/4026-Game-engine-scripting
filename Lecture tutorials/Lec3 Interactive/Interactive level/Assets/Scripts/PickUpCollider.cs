using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCollider : MonoBehaviour
{
    private bool pickedUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if (pickedUp == true)
        {

        
        GUI.Box(
            new Rect(
                Screen.width / 2 - 100,
                Screen.height / 2 - 25,
                200,
                50),
            "You got the sphere!"
            );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickedUp = true;
            GetComponent<Renderer>().enabled = false;
        }
    }
}
