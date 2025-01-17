using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShotScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    //EnemyHealth enemyHealth;
    public float bulletForce = 10;

    CannonMovementScript cannonMovementScript;

    private AudioSource audioSource;

    public void SpawnBullet()
    {

        cannonMovementScript = GetComponent<CannonMovementScript>();

        // Check if the bullet prefab is assigned
        if (bulletPrefab != null)
        {

            audioSource = GetComponent<AudioSource>();
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.Play();

            // Instantiate the bullet at the spawner's position and rotation
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            bullet.SetActive(true);

            // Get the Rigidbody2D component of the bullet
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                // Apply a force in the upward direction of the spawner
                rb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
            }
        }
        else
        {
            Debug.LogError("Bullet prefab is not assigned!");
        }
    }

    
}
