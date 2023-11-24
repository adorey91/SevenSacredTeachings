using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEditor.Rendering;

public class cameraOptions : MonoBehaviour
{
    public Toggle cameraInvert;
    public Slider cameraSpeed;

    [Header("Panels")]
    public GameObject pauseMenuUI;
    public GameObject CameraUI;

    public GameObject resumeButton;

    private CinemachineFreeLook freeLook;

    // Start is called before the first frame update
    void Start()
    {
        freeLook = DontDestroy.Instance.FreeLookCamera;

        cameraInvert.onValueChanged.AddListener(InvertXAxis);
        cameraSpeed.onValueChanged.AddListener(OnSpeedSliderChanged);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            backButton();
        }
    }

    private void InvertXAxis(bool isOn)
    {
        freeLook.m_XAxis.m_InvertInput = isOn;
    }

    private void OnSpeedSliderChanged(float value)
    {
        freeLook.m_XAxis.m_MaxSpeed = value;
    }

    public void backButton()
    {
        CameraUI.SetActive(false);
        pauseMenuUI.SetActive(true);

        if (Gamepad.current != null || Joystick.current != null)
        {
            EventSystem.current.SetSelectedGameObject(resumeButton);
        }
    }
}
