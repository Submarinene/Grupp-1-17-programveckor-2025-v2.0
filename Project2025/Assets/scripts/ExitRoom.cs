using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitRoom : MonoBehaviour
{
    EnterRoom enterRoom;

    public GameObject mainCamera;
    CameraMovement cameraMovement;

    private void Start()
    {
        enterRoom = GetComponent<EnterRoom>();
        cameraMovement = mainCamera.GetComponent<CameraMovement>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Room exited");
        cameraMovement.trackingTarget = 0;
        cameraMovement.cameraSize = cameraMovement.cameraDefaultSize;
    }
}
