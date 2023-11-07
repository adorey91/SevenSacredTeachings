using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class FirstLevelMovement : MonoBehaviour
{
    // input fields
    private ThirdPersonActionsAsset playerActionsAsset;
    private InputAction move;

    // movement fields
    private Rigidbody rb;
    public float movementForce = 1f;
    public float maxSpeed = 5f;
    private Vector3 forceDirection = Vector3.zero;


    // camera reference
    public Camera playerCamera;

    public static FirstLevelMovement Camera;

    private void Awake()
    {
        Cursor.visible = false;
        rb = this.GetComponent<Rigidbody>();
        playerActionsAsset = new ThirdPersonActionsAsset();

    }

    private void OnEnable()
    {
        move = playerActionsAsset.Player.Move;
        playerActionsAsset.Player.Enable();
    }

    private void FixedUpdate()
    {
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
        {
            LookAt();
        }
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
}
