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
    public Vector3 direction;

    public float bulletForce;
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
        direction = player.transform.position - bulletPos.position;

        // Calculate the angle in radians
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Create a rotation vector3 with x and y as 0, and z as the calculated angle
        Vector3 rotation = new Vector3(0, 0, angle + 90);

        // Instantiate the bullet with the calculated rotation
        GameObject clone = Instantiate(bullet, bulletPos.position + direction.normalized, Quaternion.Euler(rotation));
        clone.SetActive(true);
        clone.AddComponent<bulletDestroyOnTime>();
        Rigidbody2D cloneRB = clone.GetComponent<Rigidbody2D>();
        cloneRB.AddForce(direction.normalized * bulletForce, ForceMode2D.Impulse);
    }
}