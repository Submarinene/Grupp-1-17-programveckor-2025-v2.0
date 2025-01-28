using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    EnemyHealth enemyHealth;
    BreakableWallHealth breakableWallHealth;

    public int bulletDamage = 1;

    public float maxTravelDistance = 15f; // Maximum distance the bullet can travel

    private Vector3 startPosition; // Starting position of the bullet

    AudioSource bulletHit_Wall;

    Camera mainCamera;


    public List<string> allowedNames = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);

        if (transform.position == new Vector3(9999, 9999, 0))
        {
            gameObject.SetActive(false);
        }

        mainCamera = Camera.main;

        // Record the initial position of the bullet
        startPosition = transform.position;
    }

    private void Update()
    {
        // Check if the bullet has traveled beyond the maximum distance
        if (Vector3.Distance(startPosition, transform.position) > maxTravelDistance)
        {
            Debug.Log($"{gameObject.name} has traveled beyond the maximum distance and will be destroyed.");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(gameObject);
        Debug.Log($"{gameObject.name} has hit {collision.gameObject.name}.");

        if (collision.gameObject.layer == 8)
        {
            breakableWallHealth = collision.gameObject.GetComponent<BreakableWallHealth>();
            breakableWallHealth.Hurt(bulletDamage);
        }
        else if (collision.gameObject.layer == 6)
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
