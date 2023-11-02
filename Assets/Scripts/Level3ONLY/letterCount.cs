using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class letterCount : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rb;

    public GameObject freelookCamera;

    private int letterAmount; // counts list objects
    public List<GameObject> letters; // list that contains game objects
    private int collectCount = 0;
    public GameObject winText;

    public static letterCount Instance;

    private int redToBlueChangeCount = 0;

    private void Start()
    {
        letterAmount = letters.Count; // counts the amount of gameobjects stored in the list "letters"
        letters[collectCount].SetActive(false);

        winText.SetActive(false);  // turns off win text at the beginning

        rb = player.GetComponent<Rigidbody>();
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
        if (collectCount >= letterAmount) // amount of pick ups in level one
        {
            Cursor.visible = true;
            winText.SetActive(true); // win text is active
            rb.isKinematic = true;
            freelookCamera.SetActive(false);
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
