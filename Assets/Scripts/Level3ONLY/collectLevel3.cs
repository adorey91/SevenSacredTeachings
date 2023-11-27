using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class collectLevel3 : MonoBehaviour
{
    public GameObject hands;
    [SerializeField]bool canPickup;
    GameObject ObjectIwant;
    GameObject bebsiCan;

    [SerializeField]
    bool playerItem;

    private void OnTriggerEnter(Collider other)
    {
        if (playerItem == false && hands.transform.childCount == 0)
        {
            if (other.gameObject.CompareTag("item") || other.gameObject.CompareTag("trash"))
            {
                canPickup = true;
                ObjectIwant = other.gameObject;
                bebsiCan = other.transform.GetChild(0).gameObject;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canPickup = false;
    }


    private void Update()
    {
        if (canPickup == true)
        {
            if ((Input.GetKeyDown("e")) || (Input.GetButtonDown("Pickup")))
            {
                ObjectIwant.GetComponent<Rigidbody>().isKinematic = true;
                ObjectIwant.transform.position = hands.transform.position;
                ObjectIwant.transform.parent = hands.transform;
                ObjectIwant.transform.GetComponent<Collider>().enabled = false;
                bebsiCan.transform.GetComponent <Collider>().enabled = false;
                
                if (hands.transform.childCount > 0)
                {
                    playerItem = true;
                }
            }
        }
     
        if ((Input.GetKeyDown("q") || (Input.GetButtonDown("Drop")))&& playerItem == true)
        {
            ObjectIwant.GetComponent<Rigidbody>().isKinematic = false;
            ObjectIwant.transform.parent = null;
            ObjectIwant.transform.GetComponent<Collider>().enabled = true;
            bebsiCan.transform.GetComponent<Collider>().enabled = true;
            
            if (hands.transform.childCount == 0)
            {
                playerItem = false;
            }
        }
    }
}
