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
    public GameObject winPanel;
    public GameObject freelookCamera;
    public GameObject player;
    private Rigidbody rb;

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

        winCount();
    }

    void winCount()
    {
        if (collectionCount == englishLetters.Count)
        {
            Cursor.visible = true;
            winPanel.SetActive(true);
            rb.isKinematic = true;
            freelookCamera.SetActive(false);
            collectionText.SetActive(false);
        }
    }
}
