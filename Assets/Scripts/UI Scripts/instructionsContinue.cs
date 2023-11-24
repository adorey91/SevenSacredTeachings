using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class instructionsContinue : MonoBehaviour
{
    [SerializeField]
    private Button clickContinue;

    void Update()
    {
        if (Input.GetButtonDown("Submit"))
            clickContinue.onClick.Invoke();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
