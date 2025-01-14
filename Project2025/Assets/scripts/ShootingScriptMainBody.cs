using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScriptMainBody : MonoBehaviour
{

    public GameObject cannonL;
    public GameObject cannonR;

    CannonShotScript cannonShotL;
    CannonShotScript cannonShotR;

    public GameObject tutorialTextObject;

    TutorialText tutorialTextScript;

    bool isShootActive;
    public float shootSpeed;
    private float timeSinceShot = 0;
    bool isRight = false;

    private void Start()
    {
        cannonShotL = cannonL.GetComponent<CannonShotScript>();
        cannonShotR = cannonR.GetComponent<CannonShotScript>();
        tutorialTextScript = tutorialTextObject.GetComponent<TutorialText>();

        isShootActive = true;
    }

    private void Update()
    {
        if(timeSinceShot < shootSpeed)
        {
            timeSinceShot += Time.deltaTime;
        }

        if (tutorialTextObject != null)
        {
            if(tutorialTextScript.step > 5 && Input.GetMouseButton(0) && isShootActive && timeSinceShot >= shootSpeed)
            {
                timeSinceShot -= shootSpeed;

                if(isRight)
                {
                    isRight = false;
                    cannonShotL.
                }
                else
                {
                    isRight = true;
                    cannonShotR.
                }
            }
        }
        else
        {
            if (Input.GetMouseButton(0) && isShootActive && timeSinceShot >= shootSpeed)
            {



            }
        }
    }
}
