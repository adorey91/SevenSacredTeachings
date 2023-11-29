using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class cameraOptions : MonoBehaviour
{
    [Header("Camera Options")]
    public Toggle cameraInvert;
    public Slider cameraSpeed;

    [Header("Panels")]
    public GameObject cameraPanel;
    public GameObject pausePanel;

    [Header("Button")]
    public GameObject resumeButton;

    private CinemachineFreeLook freelookCamera;

    public void Awake()
    {
        freelookCamera = DontDestroy.Instance.FreeLookCamera;

        cameraInvert.onValueChanged.AddListener(InvertXAxis);
        cameraSpeed.onValueChanged.AddListener(OnSpeedSliderChanged);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause") && pausePanel.activeSelf == false)
        {
            backButton();
        }
    }

    private void InvertXAxis(bool isOn)
    {
        freelookCamera.m_XAxis.m_InvertInput = isOn;
    }

    private void OnSpeedSliderChanged(float value)
    {
        freelookCamera.m_XAxis.m_MaxSpeed = value;
    }

    public void backButton()
    {
        cameraPanel.SetActive(false);
        pausePanel.SetActive(true);
        if (Gamepad.current != null || Joystick.current != null)
        {
            EventSystem.current.SetSelectedGameObject(resumeButton);
        }
    }
}
