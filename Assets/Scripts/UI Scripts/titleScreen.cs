using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class titleScreen : MonoBehaviour
{
    public GameObject startButton;
    public GameObject quitButton;
    private AudioSource audioStart;
    private AudioSource audioExit;
    private Button playButton;
    private Button exitButton;

    public void Start()
    {
        audioStart = startButton.GetComponent<AudioSource>();
        playButton = startButton.GetComponent<Button>();
        audioStart.playOnAwake = false;

        audioExit = quitButton.GetComponent<AudioSource>();
        exitButton = quitButton.GetComponent<Button>();
        audioExit.playOnAwake = false;
    }

    public void Update()
    {
        //if (Gamepad.current != null)
        //{
        //    if (!EventSystem.current.currentSelectedGameObject)
        //    {
        //        EventSystem.current.SetSelectedGameObject(startButton);
        //    }
        //}

        if (Input.GetButtonDown("Submit"))
        {
            if (EventSystem.current.currentSelectedGameObject == startButton)
            {
                PlayButtonClickSound(audioStart);
                Invoke("ClickStart", audioStart.clip.length);
            }
            else if (EventSystem.current.currentSelectedGameObject == exitButton)
            {
                PlayButtonClickSound(audioExit);
                Invoke("QuitGame", audioExit.clip.length);
            }
        }
    }
    private void PlayButtonClickSound(AudioSource audioSource)
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    public void clickStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() 
    {
        Application.Quit();
        Debug.Log("Quitting Game");
    }
}
