﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WristTrigger : MonoBehaviour
{
    public Material pickUpMaterial;
    public Material activatedPickUpMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")){
            if (other.gameObject.GetComponent<MeshRenderer>().sharedMaterial.Equals(activatedPickUpMaterial))
            {
                other.gameObject.GetComponent<MeshRenderer>().material = pickUpMaterial;
            }
        }
    }
}
