using UnityEngine;
using Cinemachine;

public class DontDestroy : MonoBehaviour
{
    // Singleton pattern to ensure only one instance exists
    private static DontDestroy instance;

    // Reference to the Cinemachine FreeLook Camera
    private CinemachineFreeLook freeLookCamera;

    public static DontDestroy Instance
    {
        get
        {
            if (instance == null)
            {
                // Try to find an existing instance in the scene
                instance = FindObjectOfType<DontDestroy>();

                // If no instance exists, create a new GameObject and attach the script
                if (instance == null)
                {
                    GameObject go = new GameObject("");
                    instance = go.AddComponent<DontDestroy>();
                }
            }
            return instance;
        }
    }

    // Property to access the Cinemachine FreeLook Camera
    public CinemachineFreeLook FreeLookCamera
    {
        get { return freeLookCamera; }
    }

    private void Awake()
    {
        // Ensure that this instance persists across scenes
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        // Try to find the Cinemachine FreeLook Camera in the scene
        freeLookCamera = FindObjectOfType<CinemachineFreeLook>();
    }
}
