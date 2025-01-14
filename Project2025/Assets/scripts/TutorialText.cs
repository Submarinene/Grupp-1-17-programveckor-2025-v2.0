using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialText : MonoBehaviour
{
    public int step;

    TextMeshProUGUI textMeshProUGUI;

    void Start()
    {
        step = 1;
        textMeshProUGUI = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
         if(step == 1)
        { textMeshProUGUI.text = "Move Mouse to adjust the player Direction"; }
        if (step == 2)
        { textMeshProUGUI.text = "W A S D to Move"; }
        if (step == 3)
        { textMeshProUGUI.text = "The Player moves towards and around the Focus-Point"; }
        if (step == 4)
        { textMeshProUGUI.text = "Right-Click to place the focuspoint"; }
        if (step == 5)
        { textMeshProUGUI.text = "Double-Right-Click to bring back the focuspoint"; }
        if (step == 6)
        { textMeshProUGUI.text = "Left-Click to shoot"; }


    }
}
