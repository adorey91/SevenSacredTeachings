using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOffContinue : MonoBehaviour
{
    public GameObject continueButton;
    void Start()
    {
        continueButton.SetActive(false);
    }
}
