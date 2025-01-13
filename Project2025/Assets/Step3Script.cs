using UnityEngine;
using TMPro;
using System.Collections;

public class TutorialStepTimer : MonoBehaviour
{
    public TutorialText tutorialText; // Reference to the TutorialText object
    private float stepStartTime = 0f; // Time when the specific step started
    private bool thresholdCrossed = false; // Flag to check if threshold is crossed

    // Threshold time in seconds
    public float timeThreshold = 6f;

    // Reference to the TextMeshPro component
    private TextMeshPro textMeshPro;

    bool isActivated = false;

    void Start()
    {
        // Get the TextMeshPro component
        textMeshPro = GetComponent<TextMeshPro>();
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
                OnThresholdCrossed();
            }
        }
        else
        {
            // Reset timing if the step is not 3
            stepStartTime = 0f;
        }
    }

    // Action to take when threshold is crossed
    void OnThresholdCrossed()
    {
        Debug.Log("6 seconds have passed since tutorialText.step == 3.");
        if (textMeshPro != null)
        {
            StartCoroutine(FadeTextOutAndIn());
        }
    }

    // Coroutine to fade the text out and back in
    IEnumerator FadeTextOutAndIn()
    {
        // Fade out over 1 second
        float fadeDuration = 1f;
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);
            textMeshPro.color = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, alpha);
            yield return null;
        }
        textMeshPro.color = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, 0f);


        tutorialText.step++;
        // Wait for 1 second
        yield return new WaitForSeconds(1f);

        // Fade in over 1 second
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, t / fadeDuration);
            textMeshPro.color = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, alpha);
            yield return null;
        }
        textMeshPro.color = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, 1f);

        isActivated = true;

    }
}
