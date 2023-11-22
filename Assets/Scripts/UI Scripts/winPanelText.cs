using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class winPanelText : MonoBehaviour
{
    public TMP_Text mikmaqLevelName;
    public TMP_Text englishLevelName;
    public TMP_Text winPanelMikmaqLevelName;
    public TMP_Text winPanelEnglishLevelName;
    public TMP_Text winPanelQuote;
    public TMP_Text levelQuote;
    
    void Start()
    {
        winPanelMikmaqLevelName.text = mikmaqLevelName.text;
        winPanelEnglishLevelName.text = englishLevelName.text;
        winPanelQuote.text = levelQuote.text;
    }
}
