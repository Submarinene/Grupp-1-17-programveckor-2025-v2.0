using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMovementScript : MonoBehaviour
{
    public GameObject mainBody;
    public GameObject focusPoint; // Reference to the FocusPoint object
    public Vector3 cannonPosition; // Local position offset from the mainBody
    public float positionSmoothness; // Controls the smoothness of position following

    private Vector3 movementDirection = Vector3.zero;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Reset movement direction
        movementDirection = Vector3.zero;

        // Apply prioritized movement logic
        if (Input.GetKey(KeyCode.W))
        {
            movementDirection += -mainBody.transform.up; // W moves up (relative to MainBody's rotation)
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movementDirection += mainBody.transform.up; // S moves down
        }

        if (Input.GetKey(KeyCode.D))
        {
            movementDirection += -mainBody.transform.right; // D moves right
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movementDirection += mainBody.transform.right; // A moves left
        }

        // Normalize the movement direction if there's input to avoid overshooting
        if (movementDirection != Vector3.zero)
        {
            movementDirection.Normalize();
        }

        // Calculate the target position for the thruster, considering MainBody's position and rotation
        Vector3 targetPosition = mainBody.transform.position + mainBody.transform.rotation * cannonPosition;

        // Smoothly interpolate the position towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.fixedDeltaTime * positionSmoothness);

        // Make the object's top face the FocusPoint
        if (focusPoint != null)
        {
            // Calculate the direction to the FocusPoint
            Vector3 directionToFocusPoint = focusPoint.transform.position - transform.position;
            directionToFocusPoint.z = 0; // Ensure rotation happens only on the 2D plane

            // Set the rotation so the top of the object faces the FocusPoint
            transform.up = directionToFocusPoint.normalized;
        }
    }
}
