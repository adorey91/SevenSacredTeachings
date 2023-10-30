using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class trashOnly : MonoBehaviour
{
    public GameObject itemHolder;
    bool canPickup;
    GameObject ObjectIwant;
    bool hasItem;

    private Renderer rend;
    private Color targetColor;
    private bool isColorChanging = false;

    public Transform trashHolder;
    private int requiredChildren = 3;

    void Start()
    {
        rend = GetComponent<Renderer>();
        targetColor = Color.red; // The initial color
        rend.material.color = targetColor; // Set the initial color
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if (hasItem == false)
        //{
            if (collision.gameObject.CompareTag("trash"))
            {
                canPickup = true;
                ObjectIwant = collision.gameObject;
            }
        //}
        //else
        //{
        //    canPickup = false;
        //}
    }

    private void OnCollisionExit(Collision collision)
    {
        canPickup = false;
    }

    private void Update()
    {
        if (isColorChanging)
        {
            // Interpolate between the current color and the target color over time
            rend.material.color = Color.Lerp(rend.material.color, targetColor, Time.deltaTime);
        }

        if (canPickup == true)
        {
            ObjectIwant.transform.position = itemHolder.transform.position;
            ObjectIwant.transform.parent = itemHolder.transform;
            ObjectIwant.transform.GetComponent<Collider>().enabled = false;
            //hasItem = true;
            ObjectIwant.GetComponent<Rigidbody>().isKinematic = true;
        }
        if (trashHolder != null)
        {
            if (trashHolder.childCount == requiredChildren)
            {
                ChangeToBlue();
            }
        }
        //else
        //{
        //    hasItem = false;
        //}

    }
    public void ChangeToBlue()
    {
        targetColor = Color.blue;
        rend.material.color = targetColor;
        isColorChanging = true;
    }
}
