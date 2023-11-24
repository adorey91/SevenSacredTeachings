using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class CameraSettings : MonoBehaviour
{
    private CinemachineFreeLook virtualCamera;
    private Transform currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        // Assuming the Cinemachine virtual camera component is attached to the same GameObject
        virtualCamera = GetComponent<CinemachineFreeLook>();

        // Set the initial target
        SetTarget();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the current target is empty or null
        if (currentTarget == null)
        {
            // If the current target is empty, find another object with the "Player" tag
            SetTarget();
        }

        // Update the Cinemachine virtual camera's follow and look at the current target
        virtualCamera.Follow = currentTarget;
        virtualCamera.LookAt = currentTarget;
    }

    // Find another object with the "Player" tag
    void SetTarget()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            currentTarget = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("No object with the 'Player' tag found.");
        }
    }
}