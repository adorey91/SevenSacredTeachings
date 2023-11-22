using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class mikmaqWordAudio : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AudioSource word;
    private GameObject hoverWord;

    void Start()
    {
        hoverWord = transform.GetChild(0).gameObject;   // hoverWord is the child of this gameObject
        word.playOnAwake = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverWord.SetActive(false);
        word.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverWord.SetActive(true);
    }
}
