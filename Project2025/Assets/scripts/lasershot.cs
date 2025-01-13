using UnityEngine;

public class laser : MonoBehaviour
{
    public float speed = 10f;           // Hastighet p� laserskottet
    public float lifetime = 2f;         // Hur l�nge skottet lever innan det f�rsvinner
    public int damage = 1;              // Skadan som skottet g�r

    private void Start()
    {
        // F�rst�r laserskottet efter en viss tid f�r att undvika att det ligger kvar
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Flyttar laserskottet fram�t baserat p� hastighet
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kollar om laserskottet tr�ffar n�got med en Collider2D
        if (collision.CompareTag("Enemy"))
        {
            // Skada fienden (om fiendescript finns)
            // Enemy enemy = collision.GetComponent<Enemy>();
            // if (enemy != null) enemy.TakeDamage(damage);

            // F�rst�r laserskottet vid kollision
            Destroy(gameObject);
        }

        // F�rst�r laserskottet �ven om det tr�ffar n�got annat �n fienden
        Destroy(gameObject);
    }
}
