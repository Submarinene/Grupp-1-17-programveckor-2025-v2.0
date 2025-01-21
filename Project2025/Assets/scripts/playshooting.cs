using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playshooting : MonoBehaviour
{
   
    public GameObject cannonL;
    public GameObject cannonR;
    EnemyHealth enemyHealth;
    CannonShotScript cannonShotL;
    CannonShotScript cannonShotR;

  //  public GameObject tutorialTextObject;
   // TutorialText tutorialTextScript;

    public bool isShootActive;
    public float shootSpeed;
    public float timeSinceShot = 0;
    bool isRight = false;

    public float shotsFired;

    private void Start()
    {
        cannonShotL = cannonL.GetComponent<CannonShotScript>();
        cannonShotR = cannonR.GetComponent<CannonShotScript>();
       // tutorialTextScript = tutorialTextObject.GetComponent<TutorialText>();

        isShootActive = true;
    }

    private void Update()
    {
        if (timeSinceShot < shootSpeed)
        {
            timeSinceShot += Time.deltaTime;
        }


        if (Input.GetMouseButton(0) && isShootActive && timeSinceShot >= shootSpeed)
        {
            timeSinceShot -= shootSpeed;

            shotsFired++;

            if (isRight)
            {
                isRight = false;
                cannonShotL.SpawnBullet();
            }
            else
            {
                isRight = true;
                cannonShotR.SpawnBullet();
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
