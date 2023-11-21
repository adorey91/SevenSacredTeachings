using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEditor.Rendering;

public class cameraOptions : MonoBehaviour
{
    public GameObject cameraToggle;
    [SerializeField] private Toggle cameraInvert;
    public Slider cameraSpeed;
    
    public GameObject pauseMenuUI;
    public GameObject CameraUI;
    public GameObject resumeButton, quitButton, cameraButton, menuButton;

    [SerializeField] CinemachineFreeLook freeLook;

    // Start is called before the first frame update
    void Start()
    {
        cameraInvert = cameraToggle.GetComponent<Toggle>();

        cameraInvert.onValueChanged.AddListener(InvertXAxis);
        cameraSpeed.onValueChanged.AddListener(OnSpeedSliderChanged);
    }

    private void Update()
    {
        // Check if any gamepad/controller is connected
        if (Gamepad.current != null || Joystick.current != null)
        {
            EventSystem.current.SetSelectedGameObject(cameraToggle);
        }
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
        resumeButton.SetActive(true);
        menuButton.SetActive(true);
        cameraButton.SetActive(true);
        quitButton.SetActive(true);

        if (Gamepad.current != null || Joystick.current != null)
        {
            EventSystem.current.SetSelectedGameObject(resumeButton);
        }
    }
}
