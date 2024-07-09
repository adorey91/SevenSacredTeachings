using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.CullingGroup;

public class GameManager : MonoBehaviour
{
    public enum Gamestate { MainMenu, Gameplay, Options, Pause, GameEnd, };

    [Header("Managers")]
    [SerializeField] private UiManager uiManager;

    [Header("Gamestate")]
    public Gamestate gameState;
    private Gamestate stateBeforeOptions;

    private void Start()
    {
        SetState(Gamestate.MainMenu);
    }

    private void Update()
    {
        SetState(gameState);
    }

    private void SetState(Gamestate state)
    {
        gameState = state;

        switch (state)
        {
            case Gamestate.MainMenu: MainMenu(); break;
            case Gamestate.Gameplay: Gameplay(); break;
            case Gamestate.Pause: Pause(); break;
            case Gamestate.Options: Options(); break;
            case Gamestate.GameEnd: GameCompleted(); break;
        }
    }

    public void EscapeState()
    {
        switch (gameState)
        {
            case Gamestate.Gameplay: LoadState(Gamestate.Pause); break;
            case Gamestate.Options: LoadState(stateBeforeOptions); break;
            case Gamestate.Pause: LoadState(Gamestate.Gameplay); break;
        }
    }

    public void LoadState(string state)
    {
        if (Enum.TryParse(state, out Gamestate gamestate))
            LoadState(gamestate);
        else
            Debug.Log("Invalid State " + state);
    }

    private void LoadState(Gamestate state)
    {
        if (state == Gamestate.Options)
            stateBeforeOptions = gameState;

        SetState(state);
    }

    private void GameCompleted()
    {
        uiManager.UI_GameEnd();
    }

    private void Options()
    {
        uiManager.UI_Options();
    }

    private void Pause()
    {
        uiManager.UI_Pause();
    }

    private void Gameplay()
    {
        uiManager.UI_GamePlay();
    }

    private void MainMenu()
    {
        uiManager.UI_MainMenu();
    }

}
