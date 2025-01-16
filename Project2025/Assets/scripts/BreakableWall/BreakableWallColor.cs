using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWallColor : MonoBehaviour
{

    EnemyHealth wallHealth;
    SpriteRenderer spriteRenderer;

    BreakableWallHealth breakableWallHealth;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        breakableWallHealth = GetComponent<BreakableWallHealth>();
    }

    private void Update()
    {
        float health = breakableWallHealth.health;
        float maxHealth = breakableWallHealth.maxHealth;

        if(breakableWallHealth.health > 0)
        {
            spriteRenderer.color = new Color(1 - ((health / maxHealth) / 2), 0.5f, 0.5f, 1);
        }
    }
}
