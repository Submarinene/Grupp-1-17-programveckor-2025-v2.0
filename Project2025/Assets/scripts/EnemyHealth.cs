using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public int maxHealth = 3;
    int currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Hurt(int hurtDamage)
    {
        currentHealth -= hurtDamage;
       
    }
}
