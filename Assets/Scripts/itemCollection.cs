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

    [Header("Text Declarations")]
    public TMP_Text winLevelMikmaq;
    public TMP_Text levelMikmaq;
    public TMP_Text winLevelEnglish;
    public TMP_Text levelEnglish;

    void Start()
    {
        englishLetters[collectionCount].SetActive(false);
        GetComponent<AudioSource>().playOnAwake = false;

        rb = player.GetComponent<Rigidbody>();

        winLevelEnglish.text = levelEnglish.text; // assigns the english level name to the win panel
        winLevelMikmaq.text = levelMikmaq.text;   // assigns the mikmaq level name to the win panel
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
