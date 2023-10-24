using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personDeliver : MonoBehaviour
{
    public GameObject hands;
    bool canPickup;
    GameObject ObjectIwant;
    bool hasItem;

    public Material colour;
    public GameObject personObject;
    private Material person;
   
    private void OnCollisionEnter(Collision collision)
    {
        if (hasItem == false)
        {
            if (collision.gameObject.CompareTag("item"))
            {
                canPickup = true;
                ObjectIwant = collision.gameObject;
            }
        }
        else
            canPickup = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        canPickup = false;
    }

    private void Update()
    {
        if (canPickup == true)
        {
            ObjectIwant.transform.position = hands.transform.position;
            ObjectIwant.transform.parent = hands.transform;
            ObjectIwant.transform.GetComponent<Collider>().enabled = false;
            hasItem = true;
            ObjectIwant.GetComponent<Rigidbody>().isKinematic = true;

            personObject.GetComponent<Renderer>().material = person;
            person = colour;

        }
        else
        {
            hasItem = false;
        }
    }
}