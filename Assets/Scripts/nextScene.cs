using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
   public void start(string level)
    {
        SceneManager.LoadScene(level);
    }
}
