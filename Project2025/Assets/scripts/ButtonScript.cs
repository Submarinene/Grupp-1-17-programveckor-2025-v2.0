using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    bool isStartButtonPressed = false;
    bool isTutorialButtonPressed = false;
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
    }

    public void OnStartButtonClick()
    {
        Debug.Log("You pressed the start button.");
        isStartButtonPressed = true;
    }

    public void OnTutorialButtonClick()
    {
        Debug.Log("You pressed tutorial button");
        isTutorialButtonPressed = true;
    }
}
