using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colourChanger : MonoBehaviour
{
    private Renderer rend;
    private Color targetColour;
    private bool isColourChanging = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        targetColor = Color.red; // The initial color
        rend.material.color = targetColour; // Set the initial color
    }

    void Update()
    {
        if (isColourChanging)
        {
            // Interpolate between the current color and the target color over time
            rend.material.color = Color.Lerp(rend.material.color, targetColor, Time.deltaTime);
        }
    }

    public void ChangeColourToBlue()
    {
        targetColour = Color.blue;
        isColorChanging = true;
    }
}