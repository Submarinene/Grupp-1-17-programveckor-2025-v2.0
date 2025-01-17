using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    EnemyHealth enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyHealth.Hurt(1);
            //Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Tiles"))
        {
            Destroy(gameObject);
        }
    }
}
