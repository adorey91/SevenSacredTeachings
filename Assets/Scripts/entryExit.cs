using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class entryExit : MonoBehaviour
{
   
    public MeshRenderer sides;
    public MeshRenderer roof;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "entry")
        {
            
            sides.enabled=false;
            roof.enabled=false;
        }
        else if (collision.gameObject.tag == "exit")
        {
            
            sides.enabled = true;
            roof.enabled = true;
        }
    }
}
