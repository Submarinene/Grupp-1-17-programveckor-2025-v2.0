using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTestScript : MonoBehaviour
{

    public float timer = 3f;
    public bool isUp;

    Rigidbody2D enemyRB;

    private void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;

        if(timer <= 0)
        {
            isUp = !isUp;
            timer += 3f;
        }

        if (isUp)
        {
            enemyRB.velocity = new Vector2(0, 5);
        }else
        {
            enemyRB.velocity = new Vector2(0, -5);
        }
    }
}
