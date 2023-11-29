using UnityEngine;
using Cinemachine;

public class DontDestroy : MonoBehaviour
{
    private static DontDestroy instance;
    private CinemachineFreeLook freeLookCamera;

    public static DontDestroy Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DontDestroy>();

                if (instance == null)
                {
                    GameObject go = new GameObject("");
                    instance = go.AddComponent<DontDestroy>();
                }
            }
            return instance;
        }
    }

    public CinemachineFreeLook FreeLookCamera
    {
        get { return freeLookCamera; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        freeLookCamera = FindObjectOfType<CinemachineFreeLook>();
    }
}
