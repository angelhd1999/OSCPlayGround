using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WristTrigger : MonoBehaviour
{
    public Material pickUpMaterial;
    public Material activatedPickUpMaterial;
    public GameObject pickUpReact;
    public GameObject UIManager;

    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
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
                source.Play();
                UIManager.GetComponent<UIManager>().UpScore();
            }
        }
    }
}
