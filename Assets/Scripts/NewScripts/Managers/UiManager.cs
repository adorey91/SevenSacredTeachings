using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private QuestManager questManager;

    [Header("UI for Non-State")]
    [SerializeField] private GameObject acknowledgment;
    [SerializeField] private GameObject instructions;
    [SerializeField] private GameObject controls;
    [SerializeField] private GameObject endLevel;
    [SerializeField] private GameObject confirmation;

    [Header("UI for State")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject gameEnd;
    [SerializeField] private GameObject gameplay;


    // Non State UI
    #region NonState_UI

    public void UI_Confirmation()
    {
        SetActiveUI(confirmation);
    }

    public void UI_Instructions()
    {
        SetActiveUI(instructions);
    }

    public void UI_Acknowledgment()
    {
        SetActiveUI(acknowledgment);
    }

    public void UI_Controls()
    {
        SetActiveUI(controls);
    }

    public void UI_EndLevel()
    {
        SetActiveUI(endLevel);
    }
    #endregion

    // State UI
    #region State_UI
    public void UI_MainMenu()
    {
        SetActiveUI(mainMenu);
    }
    
    public void UI_Options()
    {
        SetActiveUI(options);
    }

    public void UI_Pause()
    {
        SetActiveUI(pause);
    }

    public void UI_GameEnd()
    {
        SetActiveUI(gameEnd);
    }

    public void UI_GamePlay()
    {
        SetActiveUI(gameplay);
    }
    #endregion

    public void SetActiveUI(GameObject activeUI)
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        pause.SetActive(false);
        gameEnd.SetActive(false);
        gameplay.SetActive(false);
        acknowledgment.SetActive(false);
        instructions.SetActive(false);
        controls.SetActive(false);
        endLevel.SetActive(false);
        confirmation.SetActive(false);

        activeUI.SetActive(true);
    }
}
