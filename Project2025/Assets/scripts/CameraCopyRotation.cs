using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.UI.Image;

public class CameraCopyRotation : MonoBehaviour
{
    public GameObject focusPoint;
    public GameObject mainBody;
    public float angle;

    FocusPoint focusPointScript;

    public Vector3 focusPointScreenSpace;
    public Vector3 mainBodyScreenSpace;
    public Vector3 origin;

    Vector3 direction;

    private void Start()
    {
        focusPointScript = focusPoint.GetComponent<FocusPoint>();
    }

    void LateUpdate()
    {
        if (focusPoint != null && focusPointScript != null) 
        {
            mainBodyScreenSpace = Camera.main.WorldToScreenPoint(mainBody.transform.position);
            focusPointScreenSpace = Camera.main.WorldToScreenPoint(focusPoint.transform.position);
            origin = new Vector3(0, Screen.height / 2, 0);

            if (focusPointScript.mode == 1) //calculate between the mouse pointer and the main body object
            {
                // Calculate the direction vector from the origin to the target
                direction = origin - focusPointScreenSpace;
            }
            else if(focusPointScript.mode == 2) //calculate between the focus point and the main body object
            {
                // Calculate the direction vector from the origin to the target
                direction = origin - focusPointScreenSpace;
            }

            // Calculate the angle in degrees
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle - 180);
        }
        else
        {
            Debug.LogWarning("Please assign both the origin and target GameObjects. Or the FocusPoint Script to the Focus Point object.");
        }
    }
}
