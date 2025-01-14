using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialProgressBar : MonoBehaviour
{
    public GameObject tutorialTextObject;
    TutorialText tutorialText;
    TextMeshProUGUI textMeshPro;

    Step1Script step1Script;
    Step2Script step2Script;
    Step3Script step3Script;

    public GameObject progressBar;
    Image progressBarImage;
    Image image;

    RectTransform rectTransform;

    private void Start()
    {
        tutorialText = tutorialTextObject.GetComponent<TutorialText>();
        step1Script = tutorialTextObject.GetComponent<Step1Script>();
        step2Script = tutorialTextObject.GetComponent<Step2Script>();
        step3Script = tutorialTextObject.GetComponent<Step3Script>();
        rectTransform = GetComponent<RectTransform>();
        progressBarImage = progressBar.GetComponent<Image>();
        image = GetComponent<Image>();
        textMeshPro = tutorialText.GetComponent<TextMeshProUGUI>();

        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        progressBarImage.color = new Color(progressBarImage.color.r, progressBarImage.color.g, progressBarImage.color.b, 0);
    }
    // Update is called once per frame
    void Update()
    {
        if (tutorialText.step == 0)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
            progressBarImage.color = new Color(progressBarImage.color.r, progressBarImage.color.g, progressBarImage.color.b, 0);
        }
        if (tutorialText.step == 1)
        {
            rectTransform.localScale = new Vector3(step1Script.totalDistanceMoved / step1Script.movementThreshold, 1, 1);
            image.color = new Color(image.color.r, image.color.g, image.color.b, textMeshPro.color.a);
            progressBarImage.color = new Color(progressBarImage.color.r, progressBarImage.color.g, progressBarImage.color.b, textMeshPro.color.a);
        }
        if (tutorialText.step == 2)
        {
            rectTransform.localScale = new Vector3(step2Script.totalKeyPressTime / step2Script.pressThreshold, 1, 1);
            image.color = new Color(image.color.r, image.color.g, image.color.b, textMeshPro.color.a);
            progressBarImage.color = new Color(progressBarImage.color.r, progressBarImage.color.g, progressBarImage.color.b, textMeshPro.color.a);
        }
        if (tutorialText.step == 3)
        {
            rectTransform.localScale = new Vector3((Time.time - step3Script.stepStartTime) /step3Script.timeThreshold, 1, 1);
            image.color = new Color(image.color.r, image.color.g, image.color.b, textMeshPro.color.a);
            progressBarImage.color = new Color(progressBarImage.color.r, progressBarImage.color.g, progressBarImage.color.b, textMeshPro.color.a);
        }
        if (tutorialText.step == 4 || tutorialText.step == 5)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
            progressBarImage.color = new Color(progressBarImage.color.r, progressBarImage.color.g, progressBarImage.color.b, 0);
        }
        if (tutorialText.step == 6)
        {

            image.color = new Color(image.color.r, image.color.g, image.color.b, textMeshPro.color.a);
            progressBarImage.color = new Color(progressBarImage.color.r, progressBarImage.color.g, progressBarImage.color.b, textMeshPro.color.a);
        }
    }
}
