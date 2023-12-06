using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class thankAudio : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField]private AudioSource audioSource;
   
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}