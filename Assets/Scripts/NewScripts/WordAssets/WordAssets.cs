using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Word", menuName = "Mikmaq/English Asset")]
public class WordAssets : ScriptableObject
{
    public AudioClip mikmaqWordAudio;
    public string mikmaqWord;
    public string[] englishChar;

    [TextArea]
    public string quote;
}
