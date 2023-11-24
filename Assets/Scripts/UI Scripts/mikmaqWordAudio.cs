using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class mikmaqWordAudio : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject hoverWord;
    [SerializeField]private AudioSource audioSource;

    void Start()
    {
        hoverWord = transform.GetChild(1).gameObject;   // hoverWord is the child of this gameObject
        SetAudio();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetAudio();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverWord.SetActive(false);
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverWord.SetActive(true);
    }

    void SetAudio()
    {
        GameObject audioObject = GameObject.FindGameObjectWithTag("AudioSource");
        if (audioObject != null)
        {
            audioSource = audioObject.GetComponent<AudioSource>(); // Find the AudioSource in the scene
        }
        else
            Debug.Log("missing audio");
    }
}