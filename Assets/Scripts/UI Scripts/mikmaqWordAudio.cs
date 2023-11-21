using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.
using UnityEngine.InputSystem;

public class mikmaqWordAudio : MonoBehaviour, IPointerEnterHandler
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<AudioSource>().Play();
    }

}
