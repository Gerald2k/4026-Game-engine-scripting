using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject m_goBulletPrefab;

    [SerializeField]
    private float m_fBulletSpeed = 100.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        GameObject goSpawnedBullet = Instantiate(m_goBulletPrefab);
        goSpawnedBullet.transform.position = transform.position;
        goSpawnedBullet.transform.Translate(transform.forward);

        Rigidbody rbBulletBody = goSpawnedBullet.GetComponent<Rigidbody>();
        if(rbBulletBody != null)
        {
            rbBulletBody.velocity = transform.forward * m_fBulletSpeed;
        }
        Destroy(goSpawnedBullet, 3.0f);
    }
}
