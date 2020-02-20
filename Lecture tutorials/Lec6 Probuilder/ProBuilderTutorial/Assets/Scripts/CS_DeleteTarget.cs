using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_DeleteTarget : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))// If collide with bullet
        {
            Destroy(other.gameObject); // Destroy the bullet   
            FindObjectOfType<CS_TargetSpawner>().SubtractFromTargetCount(); // Subtract from the current target count
            Destroy(gameObject); //Destroy this target
        }
    }
}
