using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    EnemyHealth enemyHealth;
    BreakableWallHealth breakableWallHealth;

    public int bulletDamage = 1;

    AudioSource bulletHit_Wall;

    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);

        if(transform.position == new Vector3(9999,9999,0))
        {
            gameObject.SetActive(false);
        }

        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Check if the object is out of the camera's view
        if (!IsObjectInView())
        {
            Debug.Log($"{gameObject.name} is out of view and will be destroyed.");
            Destroy(gameObject);
        }
    }

    private bool IsObjectInView()
    {
        // Convert the object's position to viewport coordinates
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        // Check if the object is outside the viewport bounds
        return viewportPosition.x >= 0 && viewportPosition.x <= 1 &&
               viewportPosition.y >= 0 && viewportPosition.y <= 1 &&
               viewportPosition.z > 0; // Ensure it's in front of the camera
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);

        if(collision.gameObject.layer == 8)
        {
            breakableWallHealth = collision.gameObject.GetComponent<BreakableWallHealth>();
            breakableWallHealth.Hurt(bulletDamage);
        }
        else if(collision.gameObject.layer == 6)
        {
            enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.Hurt(bulletDamage);
        }
        else if (collision.gameObject.layer == 7)
        {
            GameObject bulletHit_WallObject = GameObject.Find("BulletHit_Wall");
            bulletHit_Wall = bulletHit_WallObject.GetComponent<AudioSource>();
            bulletHit_WallObject.transform.position = gameObject.transform.position;
            bulletHit_Wall.Play();

        }
    }
}
