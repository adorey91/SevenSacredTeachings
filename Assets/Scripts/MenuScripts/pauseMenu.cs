using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    [SerializeField] private bool gameIsPaused = false;

    [Header("Panels")]
    public GameObject pausePanel;
    public GameObject winPanel;
    public GameObject cameraPanel;

    [Header("Camera")]
    public GameObject freelookCamera;

    [Header("Text Objects")]
    public TMP_Text pauseLevelName;

    private Rigidbody rb;

    private void Awake()
    {
        setText();
        findPlayer();
    }

    public void Update()
    {
        if (Input.GetButtonDown("Pause") && cameraPanel.activeSelf == false && winPanel.activeSelf == false)
        {
            setText();
            findPlayer();

            if (gameIsPaused)
                resumeGame();
            else
                pauseGame();
        }
    }

    public void pauseGame()
    {
        if (winPanel.activeSelf)
            return;
        else
        {
            pausePanel.SetActive(true);
            freelookCamera.SetActive(false);
            rb.isKinematic = true;
            Cursor.visible = true;
            gameIsPaused = true;
            Time.timeScale = 0f;
        }

    }

    public void resumeGame()
    {
        pausePanel.SetActive(false);
        cameraPanel.SetActive(false);
        freelookCamera.SetActive(true);
        rb.isKinematic = false;
        Cursor.visible = false;
        gameIsPaused = false;
        Time.timeScale = 1f;

    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void returnToTitle()
    {
        winPanel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("0. Title");
    }

    private void findPlayer()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            rb = playerObject.GetComponent<Rigidbody>();
        }
    }

    private void setText()
    {
        GameObject textObject = GameObject.FindGameObjectWithTag("MikmaqLevel");
        if (textObject != null)
        {
            TMP_Text word = textObject.GetComponent<TMP_Text>();
            if (word != null)
            {
                pauseLevelName.text = word.text;
            }
        }
    }
    
    public void cameraOptions()
    {
        cameraPanel.SetActive(true);
        pausePanel.SetActive(false);
    }

}
