using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ThirdPersonController : MonoBehaviour
{
    // input fields
    private ThirdPersonActionsAsset playerActionsAsset;
    private InputAction move;

    // movement fields
    private Rigidbody rb;
    public float movementForce = 2f;
    public float maxSpeed = 8f;
    private Vector3 forceDirection = Vector3.zero;

    // camera reference
    [SerializeField] private Camera playerCamera;

    public itemCollection item;

    private void Awake()
    {
        Cursor.visible = false;
        rb = this.GetComponent<Rigidbody>();
        playerActionsAsset = new ThirdPersonActionsAsset();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        findPlayer();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnEnable()
    {
        move = playerActionsAsset.Player.Move;
        playerActionsAsset.Player.Enable();
    }

    private void FixedUpdate()
    {
        IsGrounded();

        forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(playerCamera) * movementForce;
        forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(playerCamera) * movementForce;

        rb.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;

        if (rb.velocity.y < 0f)
            rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;

        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;

        if (!EventSystem.current.IsPointerOverGameObject())
            LookAt();
    }

    public void LookAt()
    {
        Vector3 direction = rb.velocity;
        direction.y = 0f;

        if (move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
            this.rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        else
            rb.angularVelocity = Vector3.zero;
    }

    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
            Vector3 right = playerCamera.transform.right;
            right.y = 0;
            return right.normalized;
    }

    private bool IsGrounded()
    {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.21f, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.25f))
            return true;
        else
            return false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("collect"))
        {
            other.gameObject.SetActive(false);
            item.Collect();
        }
    }

    private void findPlayer()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            rb = playerObject.GetComponent<Rigidbody>();
        }
    }
}