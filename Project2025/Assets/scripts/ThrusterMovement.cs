using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ThrusterMovementScript : MonoBehaviour
{
    public GameObject mainBody;
    public Vector3 thrusterPosition; // Local position offset from the mainBody
    public float positionSmoothness; // Controls the smoothness of position following
    public float rotationSmoothness; // Controls the smoothness of rotation following

    public Vector3 movementDirection = Vector3.zero;

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

        if(movementDirection == Vector3.zero)
        {
            movementDirection += -mainBody.transform.up; // W moves up (relative to MainBody's rotation)
        }

        // Normalize the movement direction if there's input to avoid overshooting
        if (movementDirection != Vector3.zero)
        {
            movementDirection.Normalize();
        }

        // Calculate the target position for the thruster, considering MainBody's position and rotation
        Vector3 targetPosition = mainBody.transform.position + mainBody.transform.rotation * thrusterPosition;

        // Smoothly interpolate the position towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.fixedDeltaTime * positionSmoothness);

        // Calculate the target rotation for the thruster: opposite direction of the movement direction
        if (movementDirection != Vector3.zero)
        {
            // Calculate the desired rotation (opposite of the movement direction)
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, -movementDirection);

            // Smoothly rotate the thruster towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * rotationSmoothness);
        }
    }
}