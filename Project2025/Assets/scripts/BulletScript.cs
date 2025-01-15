using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    EnemyHealth enemyHealth;

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

        enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

        enemyHealth.Hurt(bulletDamage);
    }
}
