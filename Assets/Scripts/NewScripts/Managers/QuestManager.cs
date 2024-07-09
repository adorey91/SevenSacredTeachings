using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest_Manager : MonoBehaviour
{
    [SerializeField] private WordAssets[] WordAssets;

    [SerializeField] private TMP_Text englishWord;
    [SerializeField] private TMP_Text mikmaqWord;
    private int levelNumber;

    private GameObject[] collectables;

    public void FindCollectables()
    {
        // find all things that are to be collectables? idk how this will work for the things that are going to change color?
    }

    public void SetMikmaqWord(int number)
    {
        mikmaqWord.text = WordAssets[number].mikmaqWord;
        levelNumber = number;
    }

    public void SetEnglishWord()
    {
     // for each collectable connected, show one of the letters from word assets. Or add it to the string of text already shown.   
    }
}
