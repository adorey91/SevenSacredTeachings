using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour
{
    [SerializeField] private MeshRenderer sides;
    [SerializeField] private MeshRenderer roof;
    [SerializeField] private MeshRenderer windows;
    [SerializeField] private GameObject entryDoor;
    [SerializeField] private GameObject exitDoor;

    private bool isInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(isInside)
                SetHouse(true);
            else
                SetHouse(false);
        }
    }

    private void SetHouse(bool houseVisable)
    {
        sides.enabled = houseVisable;
        roof.enabled = houseVisable;
        windows.enabled = houseVisable;
        exitDoor.SetActive(!houseVisable);
        entryDoor.SetActive(houseVisable);
    }
}