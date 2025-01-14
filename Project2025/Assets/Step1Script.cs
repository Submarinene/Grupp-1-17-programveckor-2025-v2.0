using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class Step1Script : MonoBehaviour
{
    private Vector3 lastMousePosition; // Store the last mouse position
    private float totalDistanceMoved = 0f; // Accumulated distance

    // Threshold in pixels
    public float movementThreshold = 1000f;

    // Flag to check if threshold is crossed
    private bool thresholdCrossed = false;

    // Reference to the TextMeshPro component
    private TextMeshProUGUI textMeshProUGUI;


    private TutorialText tutorialText;


    bool isActivated = false;

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
            OnThresholdCrossed();
        }
    }

    // Action to take when threshold is crossed
    void OnThresholdCrossed()
    {
        Debug.Log("Mouse has moved more than " + movementThreshold + " pixels in total.");
        if (textMeshProUGUI != null)
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
            textMeshProUGUI.color = new Color(textMeshProUGUI.color.r, textMeshProUGUI.color.g, textMeshProUGUI.color.b, alpha);
            yield return null;
        }
        textMeshProUGUI.color = new Color(textMeshProUGUI.color.r, textMeshProUGUI.color.g, textMeshProUGUI.color.b, 0f);

        tutorialText.step++;

        // Wait for 1 second
        yield return new WaitForSeconds(1f);

        // Fade in over 1 second
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, t / fadeDuration);
            textMeshProUGUI.color = new Color(textMeshProUGUI.color.r, textMeshProUGUI.color.g, textMeshProUGUI.color.b, alpha);
            yield return null;
        }
        textMeshProUGUI.color = new Color(textMeshProUGUI.color.r, textMeshProUGUI.color.g, textMeshProUGUI.color.b, 1f);

        isActivated = true;
    }
}
