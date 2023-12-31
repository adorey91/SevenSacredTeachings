using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class entry : MonoBehaviour
{
    public MeshRenderer sides;
    public MeshRenderer roof;
    public MeshRenderer windows;
    public GameObject exitDoor;
    public GameObject entryDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sides.enabled = false;
            roof.enabled = false;
            windows.enabled = false;
            exitDoor.SetActive(true);
            entryDoor.SetActive(false);
        }
    }
}
