using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class pausePanel : MonoBehaviour
{
    [SerializeField] private bool gameIsPaused = false;

    [Header("Panels")]
    public GameObject winPanel;
    public GameObject cameraPanel;
    public GameObject pauseMenuPanel;

    [Header("Camera")]
    public GameObject freelookCamera;

    [Header("Text Objects")]
    public TMP_Text pauseLevelName;

    private Rigidbody rb;
    private ThirdPersonActionsAsset playerActions;
    private InputAction pause;

    private void Awake()
    {
        setText();
        findPlayer();
        playerActions = new ThirdPersonActionsAsset();
    }

    private void OnEnable()
    {
        pause = playerActions.UI.Pause;
        playerActions.UI.Enable();
        playerActions.UI.Pause.performed += OnPause;
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        if (cameraPanel.activeSelf)
            return;
        else
        {
            gameIsPaused = !gameIsPaused;

            if(gameIsPaused)
                pauseGame();
            else
                resumeGame();
        }
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

    public void resumeGame()
    {
        pauseMenuPanel.SetActive(true);
        cameraPanel.SetActive(false);
        freelookCamera.SetActive(true);
        rb.isKinematic = false;
        Cursor.visible = false;
        gameIsPaused = false;
        Time.timeScale = 1.0f;
    }

    public void pauseGame()
    {
        if (winPanel.activeSelf == true)
            return;
        else
        {
            pauseMenuPanel.SetActive(false);
            freelookCamera.SetActive(false);
            rb.isKinematic = true;
            Cursor.visible = true;
            gameIsPaused = true;
            Time.timeScale = 0f;
        }
    }

    public void loadMenu()
    {
        winPanel.SetActive(false);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("0. Title");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void cameraOptions()
    {
        cameraPanel.SetActive(true);
    }
}
