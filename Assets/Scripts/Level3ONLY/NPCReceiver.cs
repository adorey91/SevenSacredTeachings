using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class NPCReceiver : MonoBehaviour
{
    public GameObject itemHolder;
    bool canPickup;
    GameObject ObjectIwant;
    GameObject gift;

    private Renderer rend;
    private Color targetColor;
    private bool isColorChanging = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        targetColor = Color.red; // The initial color
        rend.material.color = targetColor; // Set the initial color
    }

    private void OnTriggerEnter(Collider other)
    {
        int child = itemHolder.transform.childCount;

        if (other.gameObject.CompareTag("item") && child < 1)
        {
            canPickup = true;
            ObjectIwant = other.gameObject;
            gift = other.transform.GetChild(0).gameObject;
        }
        else
            canPickup = false;
    }        
    private void Update()
    {
        if (isColorChanging)
        {
            rend.material.color = Color.Lerp(rend.material.color, targetColor, Time.deltaTime);
        }

        if (canPickup == true)
        {
            ObjectIwant.transform.GetComponent<Collider>().enabled = false;
            gift.transform.GetComponent<Collider>().enabled = false;
            ObjectIwant.GetComponent<Rigidbody>().isKinematic = true;
            ObjectIwant.transform.position = itemHolder.transform.position;
            ObjectIwant.transform.parent = itemHolder.transform;
            ChangeColorToBlue();
        }
    }

    public void ChangeColorToBlue()
    {
        targetColor = Color.blue;
        rend.material.color = targetColor;
        isColorChanging = true;
    }
}
