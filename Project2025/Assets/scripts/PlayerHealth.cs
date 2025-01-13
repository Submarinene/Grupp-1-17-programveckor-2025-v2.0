using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    GameObject[] hjärtan;
    int maxHealth = 3;
    int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }


    void GameOver()
    {
        SceneManager.LoadScene(1);
    }
    void OnCollisionEnter2D(Collision2D collision)
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
    void Update()
    {
    }
}
