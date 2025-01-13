using UnityEngine;
using TMPro;
using System.Collections;

public class Step3Script : MonoBehaviour
{
    public TutorialText tutorialText; // Reference to the TutorialText object
    private float stepStartTime = 0f; // Time when the specific step started
    private bool thresholdCrossed = false; // Flag to check if threshold is crossed

    // Threshold time in seconds
    public float timeThreshold;

    // Reference to the TextMeshPro component
    private TextMeshProUGUI textMeshPro;

    bool isActivated = false;

    public GameObject focusPoint;
    FocusPoint focusPointScript;

    private AudioSource audioSource;

    void Start()
    {
        // Get the TextMeshPro component
        textMeshPro = GetComponent<TextMeshProUGUI>();
        if (textMeshPro == null)
        {
            Debug.LogError("No TextMeshPro component found on this GameObject.");
        }

        // Ensure tutorialText is assigned
        if (tutorialText == null)
        {
            Debug.LogError("No TutorialText object assigned.");
        }
    }

    void Update()
    {
        // Check if tutorialText.step is 3
        if (tutorialText != null && tutorialText.step == 3)
        {
            // Start timing if stepStartTime is not yet set
            if (stepStartTime == 0f)
            {
                stepStartTime = Time.time;
            }

            // Check if the threshold time has passed
            if ((!thresholdCrossed && Time.time - stepStartTime >= timeThreshold) && !isActivated)
            {
                thresholdCrossed = true;
                tutorialText.isActiveTextFade = true;

                focusPointScript = focusPoint.GetComponent<FocusPoint>();
                focusPointScript.isClickAvaliable = true;
            }
        }
        else
        {
            // Reset timing if the step is not 3
            stepStartTime = 0f;
        }
    }
}
