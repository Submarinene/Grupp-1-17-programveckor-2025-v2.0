using UnityEngine;

public class laser : MonoBehaviour
{
    public float speed = 10f;           // Hastighet på laserskottet
    public float lifetime = 2f;         // Hur länge skottet lever innan det försvinner
    public int damage = 1;              // Skadan som skottet gör

    private void Start()
    {
        // Förstör laserskottet efter en viss tid för att undvika att det ligger kvar
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Flyttar laserskottet framåt baserat på hastighet
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kollar om laserskottet träffar något med en Collider2D
        if (collision.CompareTag("Enemy"))
        {
            // Skada fienden (om fiendescript finns)
            // Enemy enemy = collision.GetComponent<Enemy>();
            // if (enemy != null) enemy.TakeDamage(damage);

            // Förstör laserskottet vid kollision
            Destroy(gameObject);
        }

        // Förstör laserskottet även om det träffar något annat än fienden
        Destroy(gameObject);
    }
}
