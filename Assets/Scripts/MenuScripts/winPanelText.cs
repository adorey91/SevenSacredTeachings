using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class winPanelText : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject continueButton;


    [Header("Panel Text")]
    public TMP_Text winPanelMikmaqLevelName;
    public TMP_Text winPanelEnglishLevelName;
    public TMP_Text winPanelQuote;

    void Start()
    {
        SetText("MikmaqLevel");
        SetText("EnglishLevel");
        SetText("LevelQuote");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetText("MikmaqLevel");
        SetText("EnglishLevel");
        SetText("LevelQuote");

        if (scene.name == "4. Kepmite'taqn")
        {
            continueButton.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void SetText(string tagName)    // find game objects outside of the "Do not destroy game object for the text"
    {
        GameObject textObject = GameObject.FindGameObjectWithTag(tagName);

        if (textObject != null)
        {
            TMP_Text word = textObject.GetComponent<TMP_Text>();

            if (word != null)
            {
                if (tagName == "MikmaqLevel")
                {
                    winPanelMikmaqLevelName.text = word.text;
                }
                else if (tagName == "EnglishLevel")
                {
                    winPanelEnglishLevelName.text = word.text;
                }
                else if (tagName == "LevelQuote")
                {
                    winPanelQuote.text = word.text;
                }
            }
        }
    }

    public void LoadScene()
    {
        winPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        SetText("MikmaqLevel");
        SetText("EnglishLevel");
        SetText("LevelQuote");
    }
}
