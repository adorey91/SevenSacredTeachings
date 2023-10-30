using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class collectLevel3 : MonoBehaviour
{
    //collection declarations
    private Rigidbody rb;

    public GameObject hands;
    bool canPickup;
    GameObject ObjectIwant;
    bool playerItem;


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        GetComponent<AudioSource>().clip = collectAudio;    //audiosource pop audio		
    //        GetComponent<AudioSource>().Play();     // popaudio will play
    //        letters[collectCount].SetActive(true); // turns on a letter based on the count
    //        collectCount++; // count increases

    //    }
    //    winCount();
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("item") || collision.gameObject.CompareTag("trash"))
        {
            canPickup = true;
            ObjectIwant = collision.gameObject;
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
            if (Input.GetKeyDown("e"))
            {
                ObjectIwant.GetComponent<Rigidbody>().isKinematic = true;
                ObjectIwant.transform.position = hands.transform.position;
                ObjectIwant.transform.parent = hands.transform;
                ObjectIwant.transform.GetComponent<Collider>().enabled = false;
                playerItem = true;
            }
        }
        if (Input.GetKeyDown("q") && playerItem == true)
        {
            ObjectIwant.GetComponent<Rigidbody>().isKinematic = false;
            ObjectIwant.transform.parent = null;
            ObjectIwant.transform.GetComponent<Collider>().enabled = true;
            playerItem = false;
        }
        
            
        
    }
}
