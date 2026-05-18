using UnityEngine;

public class BombProjectile : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    private Vector2 moveDirection;

    [Header("Explosion")]
    public float explosionRadius = 2f;
    public int damage = 20;
    public float fuseTime = 2f;

    [Header("Effects")]
    public GameObject explosionEffect;

    private bool exploded = false;

    void Start()
    {
        Invoke(nameof(Explode), fuseTime);
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }

    public void SetDirection(Vector2 direction)
    {
        moveDirection = direction.normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            Explode();
        }

        if (other.CompareTag("Player"))
        {
            Explode();
        }
    }

    void Explode()
    {
        if (exploded) return;

        exploded = true;

        // Damage nearby player
        Collider2D[] hits = Physics2D.OverlapCircleAll(
            transform.position,
            explosionRadius
        );

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                PlayerHealth hp = hit.GetComponent<PlayerHealth>();

                if (hp != null)
                {
                    hp.TakeDamage(damage);
                }
            }
        }

        // Spawn explosion effect
        if (explosionEffect != null)
        {
            Instantiate(
                explosionEffect,
                transform.position,
                Quaternion.identity
            );
        }

        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}