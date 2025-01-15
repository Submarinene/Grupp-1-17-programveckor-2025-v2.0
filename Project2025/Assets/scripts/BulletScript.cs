using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    EnemyHealth enemyHealth;
    BreakableWallHealth breakableWallHealth;

    public int bulletDamage = 1;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);

        if(transform.position == new Vector3(9999,9999,0))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);

        if(collision.gameObject.name == "BreakableWall")
        {
            breakableWallHealth = collision.gameObject.GetComponent<BreakableWallHealth>();
            breakableWallHealth.Hurt(bulletDamage);
        }
        else
        {
            enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.Hurt(bulletDamage);
        }
    }
}
