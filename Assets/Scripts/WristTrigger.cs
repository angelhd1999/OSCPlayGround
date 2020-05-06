using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WristTrigger : MonoBehaviour
{
    public Material pickUpMaterial;
    public Material activatedPickUpMaterial;
    public GameObject pickUpReact;

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
            if (other.gameObject.GetComponent<PickUpCode>().activated)
            {
                other.gameObject.GetComponent<PickUpCode>().activated = false;
                other.gameObject.GetComponent<MeshRenderer>().material = pickUpMaterial;
                pickUpReact.gameObject.GetComponent<PickUpReact>().pressedPickUp = true;
            }
        }
    }
}
