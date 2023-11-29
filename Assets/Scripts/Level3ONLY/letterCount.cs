using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class letterCount : MonoBehaviour
{
    [Header("Game Objects")]
    public List<GameObject> letters; // list that contains game objects
    public GameObject progressText;
    public GameObject player;


    private int collectCount = 0;
    private int redToBlueChangeCount = 0;

    public static letterCount Instance;

    private void Start()
    {
        letters[collectCount].SetActive(false);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void winCount() // checks to see if player has won
    {
        GameObject doNotDestroyObject = GameObject.Find("DoNotDestroy");
        if (doNotDestroyObject != null)
        {
            Transform menusTransform = doNotDestroyObject.transform.Find("Menus");
            if (menusTransform != null)
            {
                Transform winPanelTransform = menusTransform.Find("winPanel");
                if (winPanelTransform != null)
                {
                    GameObject winPanel = winPanelTransform.gameObject;
                    if (winPanel != null && !winPanel.activeSelf)
                    {
                        progressText.SetActive(false);
                        Cursor.visible = true;
                        winPanel.SetActive(true); // win text is active
                    }
                }
            }
        }
    }
 
    void findCamera()
    {
        GameObject doNotDestroyObject = GameObject.Find("DoNotDestroy");
        if (doNotDestroyObject != null)
        {
            Transform freelookCameraTransform = doNotDestroyObject.transform.Find("FreeLook Camera");
            if (freelookCameraTransform != null)
            {
                GameObject freelookCamera = freelookCameraTransform.gameObject;
                if (freelookCamera != null)
                {
                    freelookCamera.SetActive(false);
                }
            }
        }
    }        

    public void IncrementCounter()

    {
        redToBlueChangeCount++;
        letters[collectCount].SetActive(true); // turns on a letter based on the count
        collectCount++; // count increases

        if (collectCount >= letters.Count) // amount of pick ups in level one
        {
            findCamera();
            winCount();
        }
    }
}
