using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; // Reference to the Main Body object
    public float smoothSpeed = 0.125f; // Speed of the camera's smooth movement
    public Vector3 offset; // Offset of the camera relative to the target

    private void FixedUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Target is not assigned to the CameraMovement script!");
            return;
        }

        // Desired position of the camera based on the target's position and the offset
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate between the current position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Update the camera's position
        transform.position = smoothedPosition;
    }
}
