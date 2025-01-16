using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public int maxHealth = 3;
    public int currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Hurt(int amount)
    {

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}