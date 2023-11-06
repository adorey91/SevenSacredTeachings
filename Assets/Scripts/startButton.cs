using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class startButton : MonoBehaviour, IPointerEnterHandler
{

    public AudioClip mikmaq;

    void start()
    {
        GetComponent<AudioSource>().playOnAwake = false; 
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<AudioSource>().clip = mikmaq;    //audiosource pop audio		
        GetComponent<AudioSource>().Play();		// popaudio will play
        Debug.Log("The cursor entered the selectable UI element.");
    }
}