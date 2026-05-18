using UnityEngine;

public class WebProjectile : MonoBehaviour
{
    [Header("Stats")]
    public float speed = 6f;
    public float lifetime = 5f;
    public int damage = 10;

    private Vector2 moveDirection;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }

    // Called by the boss when spawned
    public void SetDirection(Vector2 direction)
    {
        moveDirection = direction.normalized;

        // Rotate projectile to face direction
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Damage player
        if (other.CompareTag("Player"))
        {
            PlayerHealth hp = other.GetComponent<PlayerHealth>();

            if (hp != null)
            {
                hp.TakeDamage(damage);
            }

            Destroy(gameObject);
        }

        // Destroy on walls
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}