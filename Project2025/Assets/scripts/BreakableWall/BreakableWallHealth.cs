using UnityEngine;

public class BreakableWallHealth : MonoBehaviour
{
    [SerializeField]
    public int maxHealth = 3;
    public int health;

    BreakableWallHitSound breakableWallHitSound;

    BoxCollider2D boxCollider2D;
    SpriteRenderer spriteRenderer;

    public GameObject paritcleSystemObject;
    ParticleSystem particleSystem;

    float twoSecondTimer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        breakableWallHitSound = GetComponent<BreakableWallHitSound>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        particleSystem = GetComponent<ParticleSystem>();
        boxCollider2D.enabled = true;
    }

    public void Hurt(int amount)
    {
        breakableWallHitSound.PlaySoundHit(health, maxHealth);

        health -= amount;
        if (health <= 0)
        {
            if(twoSecondTimer == 0)
            {
                spriteRenderer.color = new Color(0, 0, 0, 0);
                boxCollider2D.enabled = false;

                breakableWallHitSound.PlaySoundDestroy();

                particleSystem.Play();
            }
            twoSecondTimer += Time.deltaTime;

            if(twoSecondTimer >= 2)
            {
                Destroy(gameObject);
            }
        }
    }
}
