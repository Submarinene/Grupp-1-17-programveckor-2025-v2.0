using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step4Script : MonoBehaviour
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
        if(tutorialText.step == 4 && !isActivated)
        {
            if(focusPoint.mode == 2)
            {
                tutorialText.isActiveTextFade = true;
                isActivated = true;
                audioSource = GetComponent<AudioSource>();
                audioSource.Play();
            }
        }
    }
}
