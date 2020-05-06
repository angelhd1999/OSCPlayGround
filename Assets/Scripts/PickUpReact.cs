using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpReact : MonoBehaviour
{

    public float reactionTime;
    public bool activeReact = true;
    public List<GameObject> pickUps = new List<GameObject>();
    public Material pickUpMaterial;
    public Material activatedPickUpMaterial;

    private GameObject activatedPickUp;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartReact());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActivatePickUp()
    {
        activatedPickUp = pickUps[Random.Range(0, pickUps.Count)];
        activatedPickUp.GetComponent<MeshRenderer>().material = activatedPickUpMaterial;
    }

    private IEnumerator StartReact()
    {
        while (activeReact)
        {
            ActivatePickUp();
            yield return new WaitForSeconds(reactionTime);
        }
    }
}
