using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusPoint : MonoBehaviour
{
    public int mode = 1; // Default mode is 1
    public bool isClickAvaliable = true;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined; // Keeps the cursor within the game window
    }

    void Update()
    {
        if(isClickAvaliable)
        {
            HandleModeSwitch();
        }
        UpdateFocusPoint();
        ManageCursorVisibility();
    }

    void HandleModeSwitch()
    {
        // Detect right mouse button click
        if (Input.GetMouseButtonDown(1))
        {
            // Single-click detected: toggle between Mode 1 (follow cursor) and Mode 2 (stationary)
            mode = (mode == 2) ? 1 : 2;
        }

        // Allow repositioning of focus point in Mode 2
        if (mode == 2)
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
            Cursor.visible = true; // Show the cursor in Mode 2
        }
    }
}
