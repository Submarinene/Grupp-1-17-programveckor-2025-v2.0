using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    bool isStartButtonPressed = false;
    bool isTutorialButtonPressed = false;
    bool isExitButtonPressed = false;
    bool isMainMenuButtonPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isStartButtonPressed == true)
        {
            SceneManager.LoadScene(2);
        }
        else if (isTutorialButtonPressed == true)
        {
            SceneManager.LoadScene(3);
        }
        else if (isExitButtonPressed)
        {
            Application.Quit();
        }
        else if (isMainMenuButtonPressed)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void OnStartButtonClick()
    {
        isStartButtonPressed = true;
    }

    public void OnTutorialButtonClick()
    {;
        isTutorialButtonPressed = true;
    }

    public void OnExitButtonClick()
    {
        isExitButtonPressed = true;
    }

    public void OnMainMenuButtonClick()
    {
        isMainMenuButtonPressed = true;
    }
}
