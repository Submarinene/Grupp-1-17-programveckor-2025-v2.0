using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementtest : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(0, 0);
         if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(5, 0);
            
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(0, 5);

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(0, -5);

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-5, 0);

        }
    }
}
