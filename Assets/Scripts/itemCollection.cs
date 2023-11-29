using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class itemCollection : MonoBehaviour
{
    [Header("Collection Declarations")]
    public List<GameObject> englishLetters;
    [SerializeField]private int collectionCount;

    [Header("Object Declarations")]
    public GameObject collectionText;
    public GameObject player;
    private Rigidbody rb;
    [SerializeField] GameObject freelookCamera;
    [SerializeField] GameObject winPanel;

    void Start()
    {
        englishLetters[collectionCount].SetActive(false);
        GetComponent<AudioSource>().playOnAwake = false;

        rb = player.GetComponent<Rigidbody>();
    }

    public void Collect()
    {
        GetComponent<AudioSource>().Play(); // play audio source
        englishLetters[collectionCount].SetActive(true); // turns on english letters
        collectionCount++;  // increases collection count

        if (collectionCount == englishLetters.Count)
        {
            rb.isKinematic = true;
            findCamera();
            winCount();
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

    void winCount()
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
                        Cursor.visible = true;
                        winPanel.SetActive(true);
                        collectionText.SetActive(false);

                    }
                }
            }
        }
    }
}
