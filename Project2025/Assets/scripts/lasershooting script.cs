using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooting : MonoBehaviour
{
    // Prefab f�r laserskottet
    public GameObject laserPrefab;

    // Positionen d�r laserskottet skapas
    public Transform firePoint;

    // Hastighet p� laserskottet
    public float laserSpeed = 10f;

    // Update k�rs en g�ng per frame
    void Update()
    {
        // Om mellanslag trycks ned, skjuter vi ett laserskott
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    // Funktion f�r att skjuta laserskott
    void Shoot()
    {
        // Skapar laserskottet fr�n prefab vid firePoint-positionen
        GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);

        // S�tter laserskottets hastighet
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.right * laserSpeed;
        }
    }
}
