using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_SpotlightBehaviour : MonoBehaviour
{
    [SerializeField]
    private Material m_mPlayerSeenMat;//Material for when the player has been seen

    [SerializeField]
    private Material m_mSearchMat;//Material for when the spotlight is searching for the player

    [SerializeField]
    private Light m_lSpotLight;//Material for when the player has been seen

    [SerializeField]
    private Renderer m_rSpotlightGlass;// Reference to the Renderer of the Glass Game Object

    [SerializeField]
    private bool m_bCanSeePlayer = false;// Whether the spotlight can actually see the player

    [SerializeField]
    private bool m_bPlayerInCone = false;// Whether or not the player is in the trigger box

    [SerializeField]
    private Transform m_tPlayerReference;

    [SerializeField]
    private LayerMask m_lmRayLayerMasks;// The layers for our raycast to take into account

    private void OnTriggerEnter(Collider a_cCollidingObject)
    {
        if (a_cCollidingObject.CompareTag("Player")) //If the object that just entered our trigger box is the player
        {
            m_bPlayerInCone = true;
        } 
    }
    private void OnTriggerExit(Collider a_cCollidingObject)
    {
        if (a_cCollidingObject.CompareTag("Player")) //If the object that just entered our trigger box is the player
        {
            m_bPlayerInCone = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_bPlayerInCone)
        {
            //Get the direction vector between the player and the spotlight
            Vector3 v3PlayerDirection = m_tPlayerReference.position - transform.position;

            RaycastHit rHit;

            if(Physics.Raycast(transform.position, v3PlayerDirection, out rHit, 100.0f, m_lmRayLayerMasks))
            {
                if (rHit.collider.CompareTag("Player")) //If the object that just entered our trigger box is the player
                {
                    m_bCanSeePlayer = true;
                }
                else
                {
                    m_bCanSeePlayer = false;
                }
            }
            else
            {
                m_bCanSeePlayer = false;
            }
        }
        else
        {
            m_bCanSeePlayer = false;
        }
        if (m_bCanSeePlayer)
        {
            transform.parent.LookAt(new Vector3(m_tPlayerReference.position.x, 0.0f, m_tPlayerReference.position.z));

            m_lSpotLight.color = m_mPlayerSeenMat.color;// Set our Spotlights colour to our materials colour
            m_rSpotlightGlass.material = m_mPlayerSeenMat;// Set our glass to our seen colour
        }
        else
        {
            m_lSpotLight.color = m_mSearchMat.color;
            m_rSpotlightGlass.material = m_mSearchMat;
        }
    }
}
