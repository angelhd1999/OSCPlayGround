using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpReact : MonoBehaviour
{

    public float reactionTime;
    public bool activeReact = true;
    public bool pressedPickUp = false;
    public List<GameObject> pickUps = new List<GameObject>();
    public Material pickUpMaterial;
    public Material activatedPickUpMaterial;

    private GameObject activatedPickUp;
    private int specificRandom;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartReact");
    }

    // Update is called once per frame
    void Update()
    {
        if (pressedPickUp) //To restart the coroutine if a pick up is pressed.
        {
            StopCoroutine("StartReact");
            StartCoroutine("StartReact");
            pressedPickUp = !pressedPickUp;
        }
    }

    private void ActivatePickUp()
    {
        if (activatedPickUp)
        {
            activatedPickUp.GetComponent<PickUpCode>().activated = false;
            activatedPickUp.GetComponent<MeshRenderer>().material = pickUpMaterial;
        }
        int finalRandom = Random.Range(0, pickUps.Count);
        if (specificRandom == finalRandom) //To change to a diferent pick up.
        {
            finalRandom = Random.Range(0, pickUps.Count);
        }
        specificRandom = finalRandom;
        activatedPickUp = pickUps[finalRandom];
        activatedPickUp.GetComponent<PickUpCode>().activated = true;
        activatedPickUp.GetComponent<MeshRenderer>().material = activatedPickUpMaterial;
    }

    public IEnumerator StartReact()
    {
        while (activeReact)
        {
            ActivatePickUp();
            yield return new WaitForSeconds(reactionTime);
        }
    }
}
