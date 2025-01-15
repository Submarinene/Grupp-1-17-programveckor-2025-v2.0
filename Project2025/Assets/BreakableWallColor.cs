using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWallColor : MonoBehaviour
{

    EnemyHealth wallHealth;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        wallHealth = GetComponent<EnemyHealth>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float health = wallHealth.health;
        float maxHealth = wallHealth.maxHealth;

        spriteRenderer.color = new Color(1 - ((health / maxHealth) / 2) , 0.5f, 0.5f, 1);
    }
}
