﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = gameObject.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null; 
    }
}
