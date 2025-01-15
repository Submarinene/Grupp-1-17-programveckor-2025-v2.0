using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBodyMovement : MonoBehaviour
{
    Rigidbody2D playerRB;
    public Transform focusPoint; // Reference to the focus point (e.g., a target object)

    public float movementAcceleration; // Acceleration applied to control movement
    public float maxSpeed; // Maximum speed for both forward/backward and circular motion
    public float defaultCircleRange; // Strength of the inward force to keep a circular path
    public float gravityScale = 0f; // Factor affecting gradual motion, defaults to 0
    public float gravityChangeRate; // Rate at which gravityScale changes

    AudioSource[] audioSources;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerRB.gravityScale = 0f; // Ensure gravity doesn't interfere with motion
        audioSources = GetComponents<AudioSource>();
    }

    void FixedUpdate()
    {
        if (focusPoint == null)
        {
            Debug.LogWarning("FocusPoint is not assigned.");
            return;
        }

        Vector2 force = Vector2.zero;
        bool isInputPressed = false;

        // Get the position of the focus point in world space
        Vector3 focusPosition = focusPoint.position;

        // Forward and backward movement (W and S keys)
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 forwardDirection = (focusPosition - transform.position).normalized;
            force += (Vector2)forwardDirection * movementAcceleration;
            isInputPressed = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 backwardDirection = (transform.position - focusPosition).normalized;
            force += (Vector2)backwardDirection * movementAcceleration;
            isInputPressed = true;
        }

        // Circular motion (A and D keys)
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Vector3 toFocus = transform.position - focusPosition;
            Vector3 tangent = Vector3.Cross(toFocus, Vector3.forward).normalized;

            // Flip tangent direction for counter-clockwise motion (D key)
            if (Input.GetKey(KeyCode.D))
            {
                tangent = -tangent;
            }

            force += (Vector2)tangent * movementAcceleration;
            isInputPressed = true;

            // Add an inward "centripetal" force to maintain circular motion
            Vector2 inwardForce = (Vector2)(-toFocus.normalized) * defaultCircleRange * playerRB.velocity.magnitude;
            force += inwardForce;
        }

        // Smoothly adjust gravityScale
        if (isInputPressed)
        {
            gravityScale = Mathf.MoveTowards(gravityScale, 1f, gravityChangeRate * Time.fixedDeltaTime);
        }
        else
        {
            gravityScale = Mathf.MoveTowards(gravityScale, 0f, gravityChangeRate * Time.fixedDeltaTime);
        }

        // Apply the total force scaled by gravityScale and top speed
        playerRB.AddForce(force.normalized * gravityScale * maxSpeed);

        // Clamp the velocity to the maximum speed
        if (playerRB.velocity.magnitude > maxSpeed)
        {
            playerRB.velocity = playerRB.velocity.normalized * maxSpeed;
        }

        audioSources[0].volume = gravityScale*2;
    }

}
