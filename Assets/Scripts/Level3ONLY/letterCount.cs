using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class letterCount : MonoBehaviour
{
    public List<GameObject> letters; // list that contains game objects
    
    public GameObject winText;
    public GameObject freelookCamera;
    public GameObject player;
    public GameObject progressText;
    
    private Rigidbody rb;

    private int collectCount = 0;
    private int redToBlueChangeCount = 0;

    public static letterCount Instance;

    private void Start()
    {
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
        if (collectCount >= letters.Count) // amount of pick ups in level one
        {
            progressText.SetActive(false);
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
