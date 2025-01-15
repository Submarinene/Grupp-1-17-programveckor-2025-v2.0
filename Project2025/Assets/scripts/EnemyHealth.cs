using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public int maxHealth = 3;
    public int health;

    BreakableWallHitSound breakableWallHitSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        breakableWallHitSound = GetComponent<BreakableWallHitSound>();
    }

    public void Hurt(int amount)
    {
        breakableWallHitSound.PlaySoundHit(health, maxHealth);

        health -= amount;
        if (health <= 0)
        {
            breakableWallHitSound.PlaySoundDestroy();
        }
    }
}
