using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    private bool GameIsPaused = false;

    [Header("Panels")]
    public GameObject winPanel;
    public GameObject pauseMenu;
    public GameObject cameraPanel;

    [Header("Text Objects")]
    public TMP_Text pauseLevelName;

    [Header("Pause Menu Buttons")]
    public GameObject resumeButton;


    private void Start()
    {
        SetText();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                EventSystem.current.SetSelectedGameObject(null);
                if (!Input.GetKeyDown(KeyCode.Escape))
                {
                    EventSystem.current.SetSelectedGameObject(resumeButton);
                }
                Pause();
            }
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetText();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void SetText()
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
     
    public void Resume()
    {
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
        cameraPanel.SetActive(false);
    }

    void Pause()
    {
        if (winPanel.activeSelf == true)
        {
            return;
        }
        else
        {
            Cursor.visible = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }

    public void LoadMenu()
    {
        pauseMenu.SetActive(false);
        winPanel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("0. Title");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void CameraOptions()
    {
        cameraPanel.SetActive(true);
        pauseMenu.SetActive(false);
    }
}
