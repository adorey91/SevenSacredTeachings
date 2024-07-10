using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int currentLevel = 0;
    public WordAssets[] WordAssets;

    private int levelNumber;

    private GameObject[] collectables;

    public string MikmaqWord()
    {
        return WordAssets[currentLevel].mikmaqWord;
    }


    public string CompleteEnglishWord(bool complete)
    {
        StringBuilder completeWord = new StringBuilder();

        if (complete)
        {
            foreach (var character in WordAssets[currentLevel].englishChar)
            {
                completeWord.Append(character);
            }
        }
        else
        {
            for (int i = 0; i < collectables.Length; i++)
            {
                completeWord.Append(WordAssets[currentLevel].englishChar[i]);
            }
        }
        return completeWord.ToString();
    }

    public string Quote()
    {
        return WordAssets[currentLevel].quote;
    }


    public void FindCollectables()
    {
        // find all things that are to be collectables? idk how this will work for the things that are going to change color?
    }

    //public void SetMikmaqWord(int number)
    //{
    //    int amount = 0;
    //    collectionText.text = $"Mi'kmaq - {WordAssets[number].mikmaqWord} / English - {WordAssets[number].englishChar[amount]}";

    //    // for each collectable connected, show one of the letters from word assets. Or add it to the string of text already shown.   
    //}

    public void CompleteLevel()
    {
        // show win screen.
        // turn off movement & camera movement & hover over mikmaq word
        currentLevel++;
    }
}
