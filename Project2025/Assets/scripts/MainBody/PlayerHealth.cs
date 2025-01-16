using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField]
    GameObject[] hjärtan;
    int maxHealth = 3;
    int health;

    AudioSource[] audioSources;

    bool isInvisible = false;

    public float invisibleTime = 3;
    public float invisibleTimer = 0;


    PolygonCollider2D polygonCollider2D;
    SpriteRenderer spriteRenderer;

    public GameObject[] bodyParts;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        audioSources = GetComponents<AudioSource>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        if(isInvisible)
        {
            polygonCollider2D.enabled = false;

            invisibleTimer += Time.deltaTime;

            for(int i = 0; i < bodyParts.Length; i++)
            {
                spriteRenderer = bodyParts[i].GetComponent<SpriteRenderer>();
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);
            }

            if(invisibleTimer >= invisibleTime)
            {
                invisibleTimer = 0;
                isInvisible = false;
            }
        }
        else
        {
            for (int i = 0; i < bodyParts.Length; i++)
            {
                spriteRenderer = bodyParts[i].GetComponent<SpriteRenderer>();
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
            }
            polygonCollider2D.enabled = true;
        }
    }


    void GameOver()
    {
        SceneManager.LoadScene(1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 relativeVelocity = collision.relativeVelocity;

        // Calculate the collision force (magnitude of the relative velocity * the mass of the object)
        float collisionForce = relativeVelocity.magnitude * GetComponent<Rigidbody2D>().mass;

        // Log or process the force
        Debug.Log("Collision Force: " + collisionForce);

        if (collisionForce > 8)
        {
            audioSources[1].volume = collisionForce / 33;
            audioSources[1].Play();
        }

        if (collision.gameObject.layer == 6)
        {
            Debug.Log("You got hit");
            health--; //lives = lives -1;
                      //hjärtan[].GetComponent<Image>().enabled = false;

            polygonCollider2D.enabled = false;
            isInvisible = true;

            if (health == 0)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
