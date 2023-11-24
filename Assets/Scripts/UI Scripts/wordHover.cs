using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.
using UnityEngine.InputSystem;

public class wordHover : MonoBehaviour, IPointerEnterHandler
{
    private AudioSource audioSource;

    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<AudioSource>().Play();	
    }
}