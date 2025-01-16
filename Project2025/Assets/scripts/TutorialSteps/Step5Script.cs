using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step5Script : MonoBehaviour
{
    TutorialText tutorialText;

    public GameObject focusPointObject;
    FocusPoint focusPoint;
    bool isActivated = false;

    private AudioSource audioSource;

    private void Start()
    {
        tutorialText = GetComponent<TutorialText>();
        focusPoint = focusPointObject.GetComponent<FocusPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((tutorialText.step == 5 && !isActivated) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (focusPoint.mode == 1 || Input.GetKeyDown(KeyCode.RightArrow))
            {
                tutorialText.isActiveTextFade = true;
                isActivated = true;
                audioSource = GetComponent<AudioSource>();
                audioSource.Play();
            }
        }
    }
}
