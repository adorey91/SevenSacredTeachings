using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine;

public class collect : MonoBehaviour
{
    //collection declarations
    public List<GameObject> letters; // list that contains game objects
    private int letterCount; // counts list objects
    private int collectCount = 0;
    
    public GameObject winText;
    
    private Rigidbody rb;

    public GameObject freelookCamera;

    // Start is called before the first frame update
    void Start()
    {
        letterCount = letters.Count; // counts the amount of gameobjects stored in the list "letters"
        letters[collectCount].SetActive(false);
        winText.SetActive(false);  // turns off win text at the beginning
        GetComponent<AudioSource>().playOnAwake = false; // makes sure handDrum isn't played at the beginning

        rb = this.GetComponent<Rigidbody>();
    }

    void winCount() // checks to see if player has won
    {
        if (collectCount == letterCount) // amount of pick ups in level one
        {
            Cursor.visible = true;
            winText.SetActive(true); // win text is active
            rb.isKinematic = true;
            freelookCamera.SetActive(false);
        }
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