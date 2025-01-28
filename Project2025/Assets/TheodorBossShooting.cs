using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TheodorBossShooting : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public Transform bulletPos;
    bool isPlayerInRange = false;
    float timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (isPlayerInRange)
        {
            if (timer > 2)
            {
                Shoot();
                timer = 0;

            }
        }


    }

    public void EnterTrigger(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    public void ExitTrigger(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
    void Shoot()
    {
        // Calculate the direction from the bullet's spawn position to the player's position
        Vector3 direction = player.transform.position - bulletPos.position;

        // Calculate the rotation needed to face the player
        Quaternion rotation = Quaternion.LookRotation(direction);
        rotation = Quaternion.Euler(0, 0, rotation.z);

        // Instantiate the bullet with the calculated rotation
        Instantiate(bullet, bulletPos.position, rotation);
    }
}
