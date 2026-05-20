using UnityEngine;

public class SpiderBossController : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public GameObject webProjectilePrefab;
    public Transform firePoint;

    private Rigidbody2D rb;

    [Header("Movement")]
    public float moveSpeed = 2f;
    public float stoppingDistance = 5f;
    public float retreatDistance = 3f;

    [Header("Attack")]
    public float attackRange = 8f;
    public float attackCooldown = 2f;
    private float attackTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        // Movement AI
        if (distance > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                moveSpeed * Time.deltaTime
            );
        }
        else if (distance < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                -moveSpeed * Time.deltaTime
            );
        }

        // Attack
        attackTimer -= Time.deltaTime;

        if (distance <= attackRange && attackTimer <= 0f)
        {
            Shoot();
            attackTimer = attackCooldown;
        }
    }

    void Shoot()
{
    if (webProjectilePrefab == null || firePoint == null || player == null)
        return;

    GameObject projObj = Instantiate(
        webProjectilePrefab,
        firePoint.position,
        Quaternion.identity
    );

    Vector2 direction = (player.position - firePoint.position).normalized;

    WebProjectile projectile = projObj.GetComponent<WebProjectile>();

    if (projectile != null)
    {
        projectile.SetDirection(direction);
    }
}
}