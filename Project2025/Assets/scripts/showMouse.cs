using UnityEngine;

public class ShowMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Enable the cursor visibility
        Cursor.visible = true;

        // Unlock the cursor to allow free movement
        Cursor.lockState = CursorLockMode.None;
    }
}
