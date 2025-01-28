using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    bool isNextLevelButtonPressed = false;

    // Update is called once per frame
    void Update()
    {
        if (isNextLevelButtonPressed == true)
        {
            SceneManager.LoadScene(6);
        }
    }

    public void OnMNextLevelButtonClick()
    {
        Debug.Log("Next Level button pressed.");
        isNextLevelButtonPressed = true;
    }
}