using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step6Script : MonoBehaviour
{
    public GameObject mainBody;
    ShootingScriptMainBody shootingScriptMainBody;

    public GameObject tutorialTextObject;
    TutorialText tutorialTextScript;

    public float shotsThreshold;

    bool isActivated = false;

    AudioSource audioSource;

    private void Start()
    {
        tutorialTextScript = tutorialTextObject.GetComponent<TutorialText>();
        shootingScriptMainBody = mainBody.GetComponent<ShootingScriptMainBody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if ((shootingScriptMainBody.shotsFired >= shotsThreshold && !isActivated) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            tutorialTextScript.isActiveTextFade = true;
            isActivated = true;
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
    }

}
