using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private GameManager gameManager;

    [Header("SFX Clips")]
    [SerializeField] private AudioClip drumCollect;

    [Header("Voice Clips")]
    [SerializeField] private AudioClip startMikmaq;
    [SerializeField] private AudioClip quitMikmaq;
    [SerializeField] private AudioClip welcomeMikmaq;
    [SerializeField] private AudioClip[] mikmaqWords;
}
