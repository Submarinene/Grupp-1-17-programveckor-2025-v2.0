using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaseplayer : MonoBehaviour
{
    
    public float moveSpeed = 2f;
    Rigidbody2D rb;
    Vector2 moveDirection;
    public Transform target;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            moveDirection = direction;

        }
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
    }


}
