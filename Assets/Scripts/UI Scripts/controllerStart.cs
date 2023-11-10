using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class controllerStart : MonoBehaviour
{
    public GameObject startButton;

    private AudioSource audioSource;
    private Button button;

    void Start()
    {
        audioSource = startButton.GetComponent<AudioSource>(); 
        button = startButton.GetComponent<Button>();
    }

    public void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            audioSource.Play();
            Invoke("clickStart", audioSource.clip.length);
        }
    }

    private void clickStart()
    {
        button.onClick.Invoke();
    }
}