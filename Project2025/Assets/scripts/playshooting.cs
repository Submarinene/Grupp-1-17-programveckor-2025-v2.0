using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayShooting : MonoBehaviour
{

    public GameObject cannonL;
    public GameObject cannonR;

    CannonShotScript cannonShotL;
    CannonShotScript cannonShotR;

  
    public bool isShootActive;
    public float shootSpeed;
    public float timeSinceShot = 0;
  //  bool isRight = false;

    public float shotsFired;

    private void Start()
    {
        cannonShotL = cannonL.GetComponent<CannonShotScript>();
        cannonShotR = cannonR.GetComponent<CannonShotScript>();
        isShootActive = true;
    }

    private void Update()
    {
        if (timeSinceShot < shootSpeed)
        {
            timeSinceShot += Time.deltaTime;
        }

       
    }
}
