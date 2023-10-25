using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class personDeliver : MonoBehaviour
{
    public GameObject hands;
    bool canPickup;
    GameObject ObjectIwant;
    bool hasItem;

    private Color angryColor = Color.red;
    private Color happyColor = Color.blue;

    public int testCount;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (hasItem == false)
        {
            if (collision.gameObject.CompareTag("item"))
            {
                canPickup = true;
                ObjectIwant = collision.gameObject;
            }
            testCount++;
        }
        else
        {
            canPickup = false;
        }
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
            colourChanger.ChangeColourToBlue();

        }
        else
        {
            hasItem = false;
        }
    }
}