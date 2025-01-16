using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRoom : MonoBehaviour
{
    public GameObject mainCamera;
    CameraMovement cameraMovement;

    public int targetNumber;
    public float cameraSize;

    private void Start()
    {
        cameraMovement = mainCamera.GetComponent<CameraMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Room " + targetNumber + " entered");
        cameraMovement.trackingTarget = targetNumber;
        cameraMovement.cameraSize = cameraSize;
    }
}
