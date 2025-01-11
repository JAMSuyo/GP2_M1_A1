using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed
    public float cameraSensitivity = 100f; // Sensitivity
    public Transform cameraTransform;

    private Rigidbody rb;
    private float pitch = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // If cameraTransform is not manually assigned in the Inspector, try to find the camera
        if (cameraTransform == null)
        {
            // Attempt to get the camera transform from a child object (camera should be a child of the player)
            cameraTransform = GetComponentInChildren<Camera>()?.transform;

            if (cameraTransform == null)
            {
                Debug.LogWarning("No camera found attached to the player. Make sure the camera is a child of the player prefab.");
            }
        }

        // Lock cursor in the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Handle mouse movement for camera rotation
        float mouseX = Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;

        // Rotate player horizontally
        transform.Rotate(0f, mouseX, 0f);

        // Rotate camera vertically (clamped)
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    void FixedUpdate()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.W)) moveZ += 1f; // Forward
        if (Input.GetKey(KeyCode.S)) moveZ -= 1f; // Backward
        if (Input.GetKey(KeyCode.A)) moveX -= 1f; // Left
        if (Input.GetKey(KeyCode.D)) moveX += 1f; // Right

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 movement = (forward * moveZ + right * moveX).normalized * moveSpeed;
        Vector3 newPosition = rb.position + movement * Time.fixedDeltaTime;

        rb.MovePosition(newPosition);
    }
}

