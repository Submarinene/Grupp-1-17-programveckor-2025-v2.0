using UnityEngine;
using TMPro;
using System.Collections;

public class Step2Script : MonoBehaviour
{
    public float totalKeyPressTime = 0f; // Total time W, A, S, or D is pressed
    private bool thresholdCrossed = false; // Flag to check if threshold is crossed

    // Threshold time in seconds
    public float pressThreshold = 3f;

    // Reference to the TextMeshPro component
    private TextMeshProUGUI textMeshPro;

    private TutorialText tutorialText;

    bool isActivated = false;

    private AudioSource audioSource;

    void Start()
    {
        // Get the TextMeshPro component
        textMeshPro = GetComponent<TextMeshProUGUI>();
        if (textMeshPro == null)
        {
            Debug.LogError("No TextMeshPro component found on this GameObject.");
        }

        tutorialText = GetComponent<TutorialText>();
    }

    void Update()
    {

        if(tutorialText.step == 2)
        {
            // Check if any of the W, A, S, or D keys are being pressed
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                totalKeyPressTime += Time.deltaTime;
            }

            // Check if the threshold is crossed
            if ((!thresholdCrossed && totalKeyPressTime >= pressThreshold) && !isActivated)
            {
                thresholdCrossed = true;
                tutorialText.isActiveTextFade = true;
                audioSource = GetComponent<AudioSource>();
                audioSource.Play();
            }
        }
    }
}
