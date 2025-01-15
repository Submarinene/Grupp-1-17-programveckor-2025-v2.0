using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaseplayer : MonoBehaviour
{

    public Transform player;
    Vector2 moveDirection;
    public float moveSpeed = 2f;
    Rigidbody2D rb;
    bool isPlayerDetected = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerDetected)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            moveDirection = direction;
        }
        else
        {
            moveDirection = new Vector2(0, 0);
        }
    }

    private void FixedUpdate()
    {
        if (isPlayerDetected)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerDetected = true;

        }
    }



    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerDetected = false;

        }

    }


}
