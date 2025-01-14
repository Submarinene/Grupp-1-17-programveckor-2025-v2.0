using System.Collections;
using UnityEngine;
using TMPro;

public class TutorialText : MonoBehaviour
{
    public int step = 0;
    private TextMeshProUGUI textMeshProUGUI;

    public bool isActiveTextFade;

    private float fadeDuration = 1f;
    private readonly string[] tutorialSteps = {
        "Move Mouse to adjust the player Direction",
        "W A S D to Move",
        "The Player moves towards and around the Focus-Point",
        "Right-Click to place the focuspoint",
        "Right-Click again to bring back the focuspoint",
        "Left-Click to shoot",
        "Break the wall to the right",
        "Complete the level"
    };

    public GameObject focusPoint;
    FocusPoint focusPointScript;

    public GameObject mainBody;
    MainBodyMovement mainBodyMovement;

    void Start()
    {
        mainBodyMovement = mainBody.GetComponent<MainBodyMovement>();

        textMeshProUGUI = gameObject.GetComponent<TextMeshProUGUI>();
        isActiveTextFade = false;
        textMeshProUGUI.color = new Color(textMeshProUGUI.color.r, textMeshProUGUI.color.g, textMeshProUGUI.color.b, 0);
        StartCoroutine(FadeTextStart());

        focusPointScript = focusPoint.GetComponent<FocusPoint>();
        focusPointScript.isClickAvaliable = false;
    }

    private void Update()
    {

        if (step == 1 || step == 0)
        {
            mainBodyMovement.enabled = false;
        }
        else
        {
            mainBodyMovement.enabled = true;
        }
        

        // Start the fade coroutine if it is active
        if (isActiveTextFade)
        {
            isActiveTextFade = false; // Prevent multiple triggers
            StartCoroutine(FadeText());
        }
    }

    private IEnumerator FadeText()
    {
        // Ensure step is within bounds
        if (step >= tutorialSteps.Length)
        {
            yield break; // Exit if there are no more steps
        }

        // Fade out
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);
            textMeshProUGUI.color = new Color(textMeshProUGUI.color.r, textMeshProUGUI.color.g, textMeshProUGUI.color.b, alpha);
            yield return null;
        }
        textMeshProUGUI.color = new Color(textMeshProUGUI.color.r, textMeshProUGUI.color.g, textMeshProUGUI.color.b, 0f);

        // Update the text for the next step
        textMeshProUGUI.text = tutorialSteps[step];
        step++;

        // Wait briefly before fading in
        yield return new WaitForSeconds(1f);

        // Fade in
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, t / fadeDuration);
            textMeshProUGUI.color = new Color(textMeshProUGUI.color.r, textMeshProUGUI.color.g, textMeshProUGUI.color.b, alpha);
            yield return null;
        }
        textMeshProUGUI.color = new Color(textMeshProUGUI.color.r, textMeshProUGUI.color.g, textMeshProUGUI.color.b, 1f);
    }

    private IEnumerator FadeTextStart()
    {
        // Ensure step is within bounds
        if (step >= tutorialSteps.Length)
        {
            yield break; // Exit if there are no more steps
        }

        // Update the text for the next step
        textMeshProUGUI.text = tutorialSteps[step];

        // Wait briefly before fading in
        yield return new WaitForSeconds(1f);

        // Fade in
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, t / fadeDuration);
            textMeshProUGUI.color = new Color(textMeshProUGUI.color.r, textMeshProUGUI.color.g, textMeshProUGUI.color.b, alpha);
            yield return null;
        }
        textMeshProUGUI.color = new Color(textMeshProUGUI.color.r, textMeshProUGUI.color.g, textMeshProUGUI.color.b, 1f);

        step++;
    }
}
