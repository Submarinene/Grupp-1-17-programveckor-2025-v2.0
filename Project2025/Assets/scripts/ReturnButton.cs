using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    bool isMainMenuButtonPressed = false;

    // Update is called once per frame
    void Update()
    {
        if (isMainMenuButtonPressed == true)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void OnMainMenuButtonClick()
    {
        Debug.Log("Return button pressed.");
        isMainMenuButtonPressed = true;
    }
}
