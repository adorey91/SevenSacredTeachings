using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class needHelpTrigger : MonoBehaviour
{
    public GameObject hiddenDoor;
    public GameObject helpText;
    public GameObject oldText;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            oldText.SetActive(false);
            hiddenDoor.SetActive(false);
            helpText.SetActive(true);
        }
    }
}
