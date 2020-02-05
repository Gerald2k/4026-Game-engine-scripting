using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour 
{
    public float explosionForce = 10;
    public float explosionRadius = 5;
    public float fuseCountdown = 3;

    //Private because it has to be called
    private bool litFuse = false;

	// Update is called once per frame
	void Update () 
    {
		if (litFuse)
        {
            //Time.deltaTime is the difference in seconds between each frame
            //So this will countdow in seconds from its initial value 3
            fuseCountdown -= Time.deltaTime;

            if (fuseCountdown <= 0)
            {
                SelfDestruct();
            }
        }
	}

    public void LightFuse()
    {
        litFuse = true;
    }

    private void SelfDestruct()
    {
        //This grabs all colliders in a sphere radius around the bomb (which we will explode)
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider collider in colliders)
        {
            Rigidbody r = collider.GetComponent<Rigidbody>();
            if (r != null)
            {
                //If it has a rigidbody
                //Adds an explosion force, from the bomb position to the rigidbody
                //We used the impulse force, as it's much more powerful
                r.AddExplosionForce(explosionForce, transform.position, explosionRadius, 0, ForceMode.Impulse);
            }
        }

        //And now we are done with affecting the other colliders its time to die
        Destroy(gameObject);
    }
}
