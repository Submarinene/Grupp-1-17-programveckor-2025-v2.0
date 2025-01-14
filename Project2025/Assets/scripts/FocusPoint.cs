using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusPoint : MonoBehaviour
{
    public LayerMask enemyLayer; // Layer to identify enemies
    private Transform target; // Current target to follow (Mode 3)
    private int mode = 1; // Default mode is 1

    private float lastClickTime = 0f; // Time of the last mouse click
    private float doubleClickThreshold = 0.3f; // Time window for detecting double click

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined; // Keeps the cursor within the game window
    }

    void Update()
    {
        HandleModeSwitch();
        UpdateFocusPoint();
        ManageCursorVisibility();
    }

    void HandleModeSwitch()
    {
        // Detect right mouse button click
        if (Input.GetMouseButtonDown(1))
        {
            // Check if this click is a double-click
            if (Time.time - lastClickTime <= doubleClickThreshold)
            {
                // Double-click detected: switch to Mode 1
                mode = 1;
                target = null; // Clear any existing target
            }
            else
            {
                // Single-click detected: handle Mode 2 and 3 logic
                Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseWorldPosition.z = 0f; // Ensure Z-coordinate matches 2D plane

                // Check for objects under the mouse cursor on the "enemy" layer
                Collider2D hit = Physics2D.OverlapPoint(mouseWorldPosition, enemyLayer);
                if (hit != null) // Enemy detected
                {
                    mode = 3; // Switch to follow enemy mode
                    target = hit.transform;
                }
                else // No enemy detected
                {
                    // Toggle between Mode 2 (stationary) and Mode 3 (follow focus point)
                    if (mode == 2)
                    {
                        mode = 3; // Start following the focus point (not enemy)
                    }
                    else
                    {
                        mode = 2; // Switch to stationary mode
                        target = null;
                    }
                }
            }

            // Update the time of the last click
            lastClickTime = Time.time;
        }

        // Allow repositioning of focus point in Mode 2 or 3
        if (mode == 2 || mode == 3)
        {
            if (Input.GetMouseButton(1)) // While right mouse button is held
            {
                Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseWorldPosition.z = 0f; // Ensure Z-coordinate matches 2D plane
                transform.position = mouseWorldPosition; // Move focus point to cursor position
            }
        }
    }

    void UpdateFocusPoint()
    {
        switch (mode)
        {
            case 1:
                // Follow cursor
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f; // Ensure Z-coordinate matches 2D plane
                transform.position = mousePosition;
                break;

            case 2:
                // Stationary mode, do nothing, keep the position
                break;

            case 3:
                // Follow target (enemy or other object)
                if (target != null)
                {
                    transform.position = target.position;
                }
                else
                {
                    mode = 2; // Fallback to stationary if target is lost
                }
                break;
        }
    }

    void ManageCursorVisibility()
    {
        if (mode == 1)
        {
            Cursor.visible = false; // Hide the cursor in Mode 1
        }
        else
        {
            Cursor.visible = true; // Show the cursor in other modes
        }
    }
}
