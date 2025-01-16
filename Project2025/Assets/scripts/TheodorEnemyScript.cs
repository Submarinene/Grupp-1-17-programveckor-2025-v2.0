using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TheodorEnemyScript : MonoBehaviour
{

    public float moveSpeed = 2f;
    Rigidbody2D rb;
    Vector2 moveDirection;
    public Transform target;

    public float targetRangeDistanche;
    public float distanceToTarget;

    bool hasSeenTarget = false;

    EnemyHealth enemyHealth;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyHealth = GetComponent<EnemyHealth>();

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

        distanceToTarget = Vector3.Distance(target.transform.position, transform.position);

        if (distanceToTarget <= targetRangeDistanche|| enemyHealth.currentHealth < enemyHealth.maxHealth)
        {
            hasSeenTarget = true;
        }

    }

    private void FixedUpdate()
    {

        if(hasSeenTarget)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }


}
