using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public int maxHealth = 3;
    public int health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    public void Hurt(int amount)
    {

        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
