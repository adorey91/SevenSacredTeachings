using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private QuestManager questManager;
    [SerializeField] private Singleton singleton;

    [Header("Camera & Bounding shape")]
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private Collider2D foundBoundingShape;
    [SerializeField] private CinemachineConfiner2D confiner2D;

    [Header("Player Spawn Location")]
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerSpawn;

    [Header("Scene Fade")]
    [SerializeField] private Animator fadeAnimator;

    private bool isLoadingScene = false;

    // Callback function to be invoked after fade animation completes
    private System.Action fadeCallback;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        fadeAnimator = GetComponent<Animator>();
        fadeAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    public void LoadScene(string sceneName)
    {
        if (isLoadingScene) return;

        isLoadingScene = true;

        Fade("FadeOut", () =>
        {
            SceneManager.sceneLoaded += OnSceneLoaded;

            switch (sceneName)
            {
                case "0. Title":
                    gameManager.LoadState("MainMenu");
                    singleton.ClearInstance();
                    break;
                case string name when name.StartsWith("Gameplay"):
                    gameManager.LoadState("Gameplay");
                    break;
                case "GameEnd":
                    gameManager.LoadState("GameEnd");
                    break;
            }
            SceneManager.LoadScene(sceneName);
        });
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        if (scene.name == "MainMenu")
        {
            isLoadingScene = false;
            return;
        }

        player = GameObject.FindWithTag("Player");

        Fade("FadeIn", () => isLoadingScene = false);
    }

    private void Fade(string fadeDir, System.Action callback = null)
    {
        fadeCallback = callback;
        fadeAnimator.SetTrigger(fadeDir);
    }

    public void FadeAnimationComplete()
    {
        fadeCallback?.Invoke();
        fadeCallback = null; // Clear the callback to prevent it from being invoked again
    }
}
