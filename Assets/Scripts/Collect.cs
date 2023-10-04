using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{
    //collection declarations
    public List<GameObject> letters;
    private int currentActiveIndex = 0;
    private int count = 0;
    public GameObject winText;
    public AudioClip handDrum;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        letters[currentActiveIndex].SetActive(false);
        winText.SetActive(false);
        GetComponent<AudioSource>().playOnAwake = false;
    }

    void winCount()
    {
        if (count >= 6) // amount of pick ups in level one
        {
            winText.SetActive(true); // win text is active
            rb.isKinematic = true;  // stops the player when wintext is active
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            GetComponent<AudioSource>().clip = handDrum;    //audiosource pop audio		
            GetComponent<AudioSource>().Play();		// popaudio will play

            other.gameObject.SetActive(false);
            letters[count].SetActive(true);
            count++;
        }
        winCount();
    }
}
