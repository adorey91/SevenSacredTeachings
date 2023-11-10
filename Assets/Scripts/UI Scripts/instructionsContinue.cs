using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instructionsContinue : MonoBehaviour
{
    [SerializeField]
    private Button clickContinue;

    void Update()
    {
        if (Input.GetButtonDown("Submit"))
            clickContinue.onClick.Invoke();
    }
}
