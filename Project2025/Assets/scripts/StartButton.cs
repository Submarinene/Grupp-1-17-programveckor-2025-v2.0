using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    bool isStartButtonPressed = false;

    // Update is called once per frame
    void Update()
    {
        if (isStartButtonPressed == true)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void OnStartButtonClick()
    {
        Debug.Log("Start button pressed.");
        isStartButtonPressed = true;
    }
}
