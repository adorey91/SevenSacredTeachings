using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class collect : MonoBehaviour
{
    //collection declarations
    private int letterCount; // counts list objects
    public List<GameObject> letters; // list that contains game objects
    private int collectCount = 0;
    public GameObject winText;
    public AudioClip collectAudio;
    private Rigidbody rb;

    public GameObject hands;
    bool canPickup;
    GameObject ObjectIwant;
    bool hasItem;

    // Start is called before the first frame update
    void Start()
    {
        letterCount = letters.Count; // counts the amount of gameobjects stored in the list "letters"
        letters[collectCount].SetActive(false);
        winText.SetActive(false);  // turns off win text at the beginning
        GetComponent<AudioSource>().playOnAwake = false; // makes sure handDrum isn't played at the beginning
    }

    void winCount() // checks to see if player has won
    {
        if (collectCount >= letterCount) // amount of pick ups in level one
        {
            Cursor.visible = true;
            winText.SetActive(true); // win text is active

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            GetComponent<AudioSource>().clip = collectAudio;    //audiosource pop audio		
            GetComponent<AudioSource>().Play();		// popaudio will play

            other.gameObject.SetActive(false); //makes collectable disappear
            letters[collectCount].SetActive(true); // turns on a letter based on the count
            collectCount++; // count increases
        }
        winCount();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("item"))
        {
            canPickup = true;
            ObjectIwant = collision.gameObject;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        canPickup = false;
    }

    private void Update()
    {
        if (canPickup == true)
        {
            if (Input.GetKeyDown("e"))
            {
                ObjectIwant.GetComponent<Rigidbody>().isKinematic = true;
                ObjectIwant.transform.position = hands.transform.position;
                ObjectIwant.transform.parent = hands.transform;
                ObjectIwant.transform.GetComponent<Collider>().enabled = false;
                hasItem = true;
            }
        }
        if (Input.GetKeyDown("q") && hasItem == true)
        {
            ObjectIwant.GetComponent<Rigidbody>().isKinematic = false;
            ObjectIwant.transform.parent = null;
            ObjectIwant.transform.GetComponent<Collider>().enabled=true;
            hasItem = false;
        }
    }
}