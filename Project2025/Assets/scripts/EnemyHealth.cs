using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public int maxHealth = 3;
<<<<<<< HEAD
    int currentHealth;
=======
    public int health;

>>>>>>> Andreassons-working-branch
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
<<<<<<< HEAD
        if (currentHealth <= 0)
=======

        health -= amount;
        if (health <= 0)
>>>>>>> Andreassons-working-branch
        {
            Destroy(gameObject);
        }
    }
    public void Hurt(int hurtDamage)
    {
        currentHealth -= hurtDamage;
       
    }
}
