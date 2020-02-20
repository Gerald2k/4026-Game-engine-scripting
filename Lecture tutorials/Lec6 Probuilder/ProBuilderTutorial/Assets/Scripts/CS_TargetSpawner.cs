using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CS_TargetSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_goTargetPrefab;

    [SerializeField]
    private int m_iMaxTargets;

    [SerializeField]
    private float m_fRadius = 100.0f;

    private int m_iCurrentTargets;

    // Update is called once per frame
    void Update()
    {
        if(m_iCurrentTargets < m_iMaxTargets) // If less than max amount   
        {
            SpawnTarget();
        }
    }

    private void SpawnTarget()
    {
        GameObject goSpawnedTarget = Instantiate(m_goTargetPrefab);
        goSpawnedTarget.transform.position = FindRandomPosition();
        goSpawnedTarget.transform.Translate(Vector3.up * Random.Range(1.0f, 5.0f)); // Move the target up a small amount
        m_iCurrentTargets++;
    }

    private Vector3 FindRandomPosition()
    {
        Vector3 v3RandomPos = Random.insideUnitSphere * m_fRadius;
        v3RandomPos += transform.position;

        NavMeshHit nmhHitInformation;

        if (NavMesh.SamplePosition(v3RandomPos, out nmhHitInformation, m_fRadius, FindObjectOfType<NavMeshAgent>().areaMask)) // find nearest valid point on navmesh from our random position 
        {
            return nmhHitInformation.position;
        }
        return Vector3.zero;
    }

    public void SubtractFromTargetCount()
    {
        m_iCurrentTargets--;
    }
}
