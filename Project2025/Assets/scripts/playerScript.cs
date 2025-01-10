using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerScript : MonoBehaviour
{
    int lives;


    [SerializeField]
    GameObject[] hearts;
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("-1 life");


        lives--; //lives = lives -1;
        hearts[lives].GetComponent<Image>().enabled = false;
        transform.position = new Vector2(0, -2); //makes the player respawn
        if (lives == 0)
        {
            //change to game over scene
            SceneManager.LoadScene("GameOver");
        }

    }
}
