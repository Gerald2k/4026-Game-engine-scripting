using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // If enemy then remove door collider to let thru
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            // Need to be changed so that it doesnt remove but allows enemy through
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
