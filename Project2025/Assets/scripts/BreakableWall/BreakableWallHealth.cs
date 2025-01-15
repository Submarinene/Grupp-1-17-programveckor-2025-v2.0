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
    private ParticleSystem wallParticleSystem;

    float destoryTime = -1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        breakableWallHitSound = GetComponent<BreakableWallHitSound>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        wallParticleSystem = paritcleSystemObject.GetComponent<ParticleSystem>();
        boxCollider2D.enabled = true;
    }

    private void Update()
    {
        if (destoryTime != -1f)
        {
            if (Time.time >= destoryTime + 2)
            {

                Destroy(gameObject);

            }
        }
    }

    public void Hurt(int amount)
    {
        breakableWallHitSound.PlaySoundHit(health, maxHealth);

        health -= amount;

        if (health <= 0)
        {
            destoryTime = Time.time;

            spriteRenderer.color = new Color(0, 0, 0, 0);
            boxCollider2D.enabled = false;

            breakableWallHitSound.PlaySoundDestroy();

            wallParticleSystem.Play();
         
        }
    }
}
