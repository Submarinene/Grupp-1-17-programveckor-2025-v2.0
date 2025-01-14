using UnityEngine;
using TMPro;
using System.Collections;

public class Step2Script : MonoBehaviour
{
    private float totalKeyPressTime = 0f; // Total time W, A, S, or D is pressed
    private bool thresholdCrossed = false; // Flag to check if threshold is crossed

    // Threshold time in seconds
    public float pressThreshold = 3f;

    // Reference to the TextMeshPro component
    private TextMeshPro textMeshPro;

    private TutorialText tutorialText;

    bool isActivated = false;

    void Start()
    {
        // Get the TextMeshPro component
        textMeshPro = GetComponent<TextMeshPro>();
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
                OnThresholdCrossed();
            }
        }
    }

    // Action to take when threshold is crossed
    void OnThresholdCrossed()
    {
        Debug.Log("W, A, S, or D has been pressed for a total of " + pressThreshold + " seconds.");
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
