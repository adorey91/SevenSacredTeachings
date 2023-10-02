using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    //Gameobjects
    public List<GameObject> letters;
    private int currentActiveIndex = 0;
    private int count = 0;
    public GameObject winText;

    // debugging text
    //public TextMeshProUGUI countText;

    // Start is called before the first frame update
    void Start()
    {
        letters[currentActiveIndex].SetActive(false);
        winText.SetActive(false);
        SetCount();
    }

    void SetCount()
    {
        // count text used for debugging
        // countText.text = count.ToString();
        if (count >= 6) // amount of pick ups in level one
        {
            // Set the text value of your 'winText'
            winText.SetActive(true); // win text is active
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            letters[count].SetActive(true);
            count++;
        }
        SetCount();
    }
}