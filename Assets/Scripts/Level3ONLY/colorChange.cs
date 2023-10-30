using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChange : MonoBehaviour
{
    private Renderer rend;
    private Color previousColor;
    private bool hasChangedFromRedToBlue = false;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        previousColor = rend.material.color;
    }

    private void Update()
    {
        Color currentColor = rend.material.color;

        if (previousColor == Color.red && currentColor == Color.blue)
        {
            if (!hasChangedFromRedToBlue)
            {
                // Color has changed from red to blue for the first time
                hasChangedFromRedToBlue = true;

                // Increment a counter
                letterCount.Instance.IncrementCounter();
            }
        }
        previousColor = currentColor;
    }
}
