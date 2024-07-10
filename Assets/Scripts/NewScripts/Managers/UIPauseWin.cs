using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILevelText : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] private QuestManager questManager;

    [Header("Text UI")]
    [SerializeField] private TMP_Text pauseLevelName;
    [SerializeField] private TMP_Text winLevelName;
    [SerializeField] private TMP_Text winEnglishLevelName;
    [SerializeField] private TMP_Text levelQuote;

    [SerializeField] private TMP_Text collectionText;


    public void AssignLevelText()
    {
        pauseLevelName.text = questManager.MikmaqWord();
        winLevelName.text = questManager.MikmaqWord();
        winEnglishLevelName.text = questManager.CompleteEnglishWord(true);
        levelQuote.text = questManager.Quote();
    }

    public void SetCollectionWord()
    {
        collectionText.text = $"Mi'kmaq - {questManager.MikmaqWord()} / English - {questManager.CompleteEnglishWord(false)}";   
    }
}
