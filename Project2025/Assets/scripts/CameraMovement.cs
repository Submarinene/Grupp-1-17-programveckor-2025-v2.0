using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform[] target; // Reference to the Main Body object
    public float smoothSpeed = 0.1f; // Speed of the camera's smooth movement
    public float roomSmoothSpeed = 0.03f;
    public Vector3 offset; // Offset of the camera relative to the target

    public int trackingTarget = 0;

    public float cameraSize; // Desired camera size
    public float cameraDefaultSize = 10; // Default camera size

    private Camera cameraComponent;

    public bool isTriggerActive = false;

    Vector3 desiredPosition;
    Vector3 smoothedPosition;
    float smoothedSize;

    private void Start()
    {
        cameraComponent = GetComponent<Camera>();
        cameraComponent.orthographicSize = cameraDefaultSize; // Set default size at the start
        cameraSize = cameraDefaultSize; // Initialize the desired size
    }

    private void FixedUpdate()
    {
        if (target == null || target.Length == 0)
        {
            Debug.LogWarning("Target is not assigned to the CameraMovement script!");
            return;
        }

        // Desired position of the camera based on the target's position and the offset
        desiredPosition = target[trackingTarget].position + offset;

        if(trackingTarget == 0 )
        {
            // Smoothly interpolate between the current position and the desired position
            smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            // Smoothly interpolate between the current size and the desired size
            smoothedSize = Mathf.Lerp(cameraComponent.orthographicSize, cameraSize, smoothSpeed);
        }
        else
        {
            // Smoothly interpolate between the current position and the desired position
            smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, roomSmoothSpeed);
            // Smoothly interpolate between the current size and the desired size
            smoothedSize = Mathf.Lerp(cameraComponent.orthographicSize, cameraSize, roomSmoothSpeed);
        }
        

        // Update the camera's position and orthographic size
        transform.position = smoothedPosition;
        cameraComponent.orthographicSize = smoothedSize;
    }
}
