using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class newCollection : MonoBehaviour
{
    //collection declarations
    public List<GameObject> letters; // list that contains game objects
    private int letterCount; // counts list objects
    private int collectCount = 0;

    public GameObject collectionText; // turns off collection text
    public GameObject winPanel;
    
    // Text declarations
    public TMP_Text levelTextObject; // Text for winMenu UI that will take from outside the prefab
    public TMP_Text LevelName;
    public TMP_Text levelEnglish;
    public TMP_Text levelEnglishWin;

    private Rigidbody rb;
    public GameObject player;

    public GameObject freelookCamera;

    void winCount() // checks to see if player has won
    {
        if (collectCount == letterCount) // amount of pick ups in level one
        {
            Cursor.visible = true;
            winPanel.SetActive(true); // win text is active
            rb.isKinematic = true;
            freelookCamera.SetActive(false);
            collectionText.SetActive(false);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();

            other.gameObject.SetActive(false);
            letters[collectCount].SetActive(true); // turns on a letter based on the count
            collectCount++; // count increases
        }
        winCount();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("collect"))
        {
            GetComponent<AudioSource>().Play();

            collision.gameObject.SetActive(false);
            letters[collectCount].SetActive(true); // turns on a letter based on the count
            collectCount++; // count increases
        }
        winCount();
    }
}