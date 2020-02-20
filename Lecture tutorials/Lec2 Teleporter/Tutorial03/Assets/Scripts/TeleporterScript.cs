using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TeleporterScript : MonoBehaviour
{

    [SerializeField]
    float MaxY;

    [SerializeField]
    float MinY;

    [SerializeField]
    float BobSpeed;

    private GameObject[] destinations;

    private void Start()
    {
        // Calls once at the start only
        destinations = GameObject.FindGameObjectsWithTag("TeleporterExit");
    }
    // Update is called once per frame
    private void Update()
    {
        //If the current Y is greater or less than MaxY or MinY
        if (transform.position.y >= MaxY || transform.position.y <= MinY)
        {
            //Invert direction of travel
            BobSpeed *= -1.0f;
        }

        //Move the sphere/teleporter
        transform.position += new Vector3(0.0f, BobSpeed * Time.deltaTime, 0.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        //If it's not the player colliding with the object - dont care
        if (other.gameObject.tag != "Player")
        {
            return;
        }

        //Sort the array of destinations by which is closest to the current objects position
        //This could slow logic if you have 100's of desinations
        destinations.OrderBy(print => Vector3.Distance(transform.position, print.transform.position)).ToArray();

        other.gameObject.transform.position = destinations[0].transform.position;

        other.gameObject.GetComponent<CharacterController>().enabled = false;
        other.gameObject.transform.position = destinations[0].transform.position;
        other.gameObject.GetComponent<CharacterController>().enabled = true;
    }
}
