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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        audioSources = GetComponents<AudioSource>();
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
    }

    private void OnTriggerEnter2D(Collision2D collision)
    {
        Debug.Log("You got hit");
        health--; //lives = lives -1;
        //hjärtan[].GetComponent<Image>().enabled = false;
        transform.position = new Vector2(0, -2); //makes the player respawn
        if (health == 0)
        {
            SceneManager.LoadScene(1);
        }

    }
}
