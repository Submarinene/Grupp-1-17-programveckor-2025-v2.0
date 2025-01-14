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
        Debug.Log("-1 life ");
        lives--; //lives = lives -1;
        if (lives < 0)
            return;
        hearts[lives].GetComponent<Animator>().SetTrigger("hit"); //s�tter ig�ng explosion
        // hearts[lives].GetComponent<Image>().enabled = false; //tar bort ett hj�rta
        transform.position = new Vector2(-7, 2); //makes the player respawn
        if (lives == 2)
        {
            StartCoroutine("GameOver");
            //change to game over scene
        }

    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3); // v�ntar # sekunder innan f�ljande kod k�rs inom metoden
        SceneManager.LoadScene("GameOver");
    }
}
