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
    
    public GameObject winPanel;
    public GameObject pauseMenuUI;
    public GameObject CameraUI;
    public GameObject mikmaqProgressText;
    public GameObject resumeButton, quitButton, cameraButton, menuButton;

    public TMP_Text pauseLevelName;
    public TMP_Text LevelName;

    private void Start()
    {
        pauseLevelName.text = LevelName.text;
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

    public void Resume()
    {
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
        mikmaqProgressText.SetActive(true);
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
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
            mikmaqProgressText.SetActive(false);
        }
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("0. Title");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void CameraOptions()
    {
        CameraUI.SetActive(true);
        resumeButton.SetActive(false);
        menuButton.SetActive(false);
        cameraButton.SetActive(false);
        quitButton.SetActive(false);
    }
}
