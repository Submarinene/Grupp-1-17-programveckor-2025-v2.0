using UnityEngine;

public class GradualRotation : MonoBehaviour
{
    public Transform focusPoint; // Reference to the object to rotate towards
    public float rotationSpeed = 360f; // Rotation speed in degrees per second

    void FixedUpdate()
    {
        if (focusPoint == null)
        {
            Debug.LogWarning("FocusPoint is not assigned.");
            return;
        }

        // Calculate the direction from the object to the focus point
        Vector3 directionToFocus = focusPoint.position - transform.position;

        // Calculate the angle to the focus point and subtract 90 degrees (for alignment)
        float targetAngle = Mathf.Atan2(directionToFocus.y, directionToFocus.x) * Mathf.Rad2Deg - 90f;

        // Get the current rotation angle
        float currentAngle = transform.eulerAngles.z;

        // Smoothly rotate towards the target angle
        float newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);

        // Apply the rotation
        transform.rotation = Quaternion.Euler(0, 0, newAngle);
    }
}
