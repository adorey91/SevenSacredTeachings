using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class letterCount : MonoBehaviour
{
    public List<GameObject> letters; // list that contains game objects
    public GameObject progressText;

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
        if (collectCount >= letters.Count) // amount of pick ups in level one
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
    }
    
    public void IncrementCounter()
    {
        redToBlueChangeCount++;
        letters[collectCount].SetActive(true); // turns on a letter based on the count
        collectCount++; // count increases

        winCount();
    }
}