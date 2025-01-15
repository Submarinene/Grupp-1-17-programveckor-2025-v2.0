using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step7Script : MonoBehaviour
{
    bool isActivated = false;

    public GameObject tutorialTextObject;
    TutorialText tutorialTextScript;

    AudioSource audioSource;

    public GameObject breakableWallOne;
    BreakableWallHealth breakableWallHealth;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        tutorialTextScript = tutorialTextObject.GetComponent<TutorialText>();
        breakableWallHealth = breakableWallOne.GetComponent<BreakableWallHealth>();
    }

    private void Update()
    {
        if (breakableWallHealth.health <= 0 && !isActivated)
        {
            tutorialTextScript.isActiveTextFade = true;
            isActivated = true;
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
    }
}
