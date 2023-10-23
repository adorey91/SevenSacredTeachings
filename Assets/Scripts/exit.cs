using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class exit : MonoBehaviour
{
    public MeshRenderer sides;
    public MeshRenderer roof;
    public MeshRenderer windows;
    public GameObject entryDoor;
    public GameObject exitDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sides.enabled = true;
            roof.enabled = true;
            windows.enabled = true;
            exitDoor.SetActive(false);
            entryDoor.SetActive(true);
        }
    }
}