using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class collectLevel3 : MonoBehaviour
{
    public GameObject hands;
    bool canPickup;
    GameObject ObjectIwant;
    GameObject bebsiCan;
    [SerializeField]
    bool playerItem;

    private void OnTriggerEnter(Collider other)
    {
        if (playerItem == false)
        {
            if (other.gameObject.CompareTag("item") || other.gameObject.CompareTag("trash"))
            {
                canPickup = true;
                ObjectIwant = other.gameObject;
                bebsiCan = other.transform.GetChild(0).gameObject;
            }
        }
    }

    private void Update()
    {
        if (canPickup == true)
        {
            if ((Input.GetKeyDown("e"))||(Input.GetButtonDown("Pickup")))
            {
                ObjectIwant.GetComponent<Rigidbody>().isKinematic = true;
                ObjectIwant.transform.position = hands.transform.position;
                ObjectIwant.transform.parent = hands.transform;
                ObjectIwant.transform.GetComponent<Collider>().enabled = false;
                bebsiCan.transform.GetComponent <Collider>().enabled = false;
                playerItem = true;
            }
        }
     
        if ((Input.GetKeyDown("q") ||(Input.GetButtonDown("Drop")))&& playerItem == true)
        {
            ObjectIwant.GetComponent<Rigidbody>().isKinematic = false;
            ObjectIwant.transform.parent = null;
            ObjectIwant.transform.GetComponent<Collider>().enabled = true;
            bebsiCan.transform.GetComponent<Collider>().enabled = true;
            playerItem = false;
        }
    }
}
