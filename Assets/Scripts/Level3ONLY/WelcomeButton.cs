using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WelcomeButton : MonoBehaviour
{
    private Color targetColor;
    private bool isColorChanging = false;

    public GameObject welcomeText;

    public GameObject npcShirt;
    public Renderer npcRend;

    void Start()
    {
        targetColor = Color.red; // The initial color
        npcRend.material.color = targetColor; // Set the initial color
    }

    private void Update()
    {
        if (isColorChanging)
        {
            // Interpolate between the current color and the target color over time
            npcRend.material.color = Color.Lerp(npcRend.material.color, targetColor, Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ChangeToBlue();
            welcomeText.SetActive(true);
            this.GetComponent<Renderer>().enabled = false;
        }
    }

    public void ChangeToBlue()
    {
        targetColor = Color.blue;
        npcRend.material.color = targetColor;
        isColorChanging = true;
    }
}