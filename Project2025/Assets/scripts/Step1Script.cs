using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class Step1Script : MonoBehaviour
{
    private Vector3 lastMousePosition; // Store the last mouse position
    private float totalDistanceMoved = 0f; // Accumulated distance

    // Threshold in pixels
    public float movementThreshold = 3000f;

    // Flag to check if threshold is crossed
    private bool thresholdCrossed = false;

    // Reference to the TextMeshPro component
    private TextMeshProUGUI textMeshProUGUI;


    private TutorialText tutorialText;


    bool isActivated = false;

    private AudioSource audioSource;

    void Start()
    {
        // Initialize the last mouse position
        lastMousePosition = Input.mousePosition;

        // Get the TextMeshPro component
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        if (textMeshProUGUI == null)
        {
            Debug.LogError("No TextMeshPro component found on this GameObject.");
        }

        tutorialText = GetComponent<TutorialText>();
    }

    void Update()
    {
        if(tutorialText.step == 1)
        {
            // Get the current mouse position
            Vector3 currentMousePosition = Input.mousePosition;

            // Calculate the distance moved since the last frame
            float distanceMoved = Vector3.Distance(currentMousePosition, lastMousePosition);

            // Accumulate the distance
            totalDistanceMoved += distanceMoved;

            // Update the last mouse position
            lastMousePosition = currentMousePosition;

            // Check if the threshold is crossed
            if ((!thresholdCrossed && totalDistanceMoved >= movementThreshold) && !isActivated)
            {
                thresholdCrossed = true;
                tutorialText.isActiveTextFade = true;
                audioSource = GetComponent<AudioSource>();
                audioSource.Play();
            }
        }
    }
}
