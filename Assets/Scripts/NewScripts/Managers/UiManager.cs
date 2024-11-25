using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [Header("UI Objects")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject gameplay;
    [SerializeField] private GameObject gameEnd;
    [SerializeField] private GameObject controls;
    [SerializeField] private GameObject acknowledgment;
    [SerializeField] private GameObject instructions;
    [SerializeField] private GameObject endLevel;
    [SerializeField] private GameObject confirmation;

    public void UI_Confirmation() => SetActiveUI(confirmation);
    public void UI_Instructions() => SetActiveUI(instructions);
    public void UI_Acknowledgment() => SetActiveUI(acknowledgment);
    public void UI_Controls() => SetActiveUI(controls);
    public void UI_EndLevel() => SetActiveUI(endLevel);
    public void UI_Gameplay() => SetActiveUI(gameplay);
    public void UI_GameEnd() => SetActiveUI(gameEnd);
    public void UI_MainMenu() => SetActiveUI(mainMenu);
    public void UI_Options() => SetActiveUI(options);
    public void UI_Pause() => SetActiveUI(pause);


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

        Debug.Log(activeUI.name + "is active");
        activeUI.SetActive(true);
    }
}
