using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class entry : MonoBehaviour
{
   
    public MeshRenderer sides;
    public MeshRenderer roof;
    public MeshRenderer windows;

    private int count = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (count == 0)
            {
                sides.enabled = false;
                roof.enabled = false;
                windows.enabled = false;
                count++;
            }
            else if (count == 1)
            {
                sides.enabled = true;
                roof.enabled = true;
                windows.enabled = true;
                count = 0;
            }
        }
    }
}
