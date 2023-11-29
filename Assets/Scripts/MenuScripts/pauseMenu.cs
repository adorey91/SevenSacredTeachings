using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine.EventSystems;
using Cinemachine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private bool gameIsPaused = false;

    [Header("Panels")]
    public GameObject winPanel;
    public GameObject cameraPanel;
    public GameObject pausePanel;

    [Header("Camera")]
    public GameObject freelookCamera;

    [Header("Objects")]
    public TMP_Text pauseLevelName;

    private Rigidbody rb;

    private void Awake()
    {
        setText();
        findPlayer();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause") && cameraPanel.activeSelf == false && winPanel.activeSelf == false)
        {
            if (gameIsPaused)
                resumeGame();
            else
                pauseGame();
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
        pausePanel.SetActive(false);
        cameraPanel.SetActive(false);
        freelookCamera.SetActive(true);
        rb.isKinematic = false;
        Cursor.visible = false;
        gameIsPaused = false;
        Time.timeScale = 1.0f;
    }

    public void pauseGame()
    {
        pausePanel.SetActive(true);
        freelookCamera.SetActive(false);
        rb.isKinematic = true;
        Cursor.visible = true;
        gameIsPaused = true;
        Time.timeScale = 0f;
    }

    public void loadMenu()
    {
        pausePanel.SetActive(false);
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
        pausePanel.SetActive(false);
    }
}