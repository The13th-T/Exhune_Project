using UnityEngine;

public class GoblinBossController : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public Transform attackPoint;

    [Header("Bomb Attack")]
    public GameObject bombPrefab;
    public Transform throwPoint;
    public float throwCooldown = 3f;

    [Header("Stats")]
    public int maxHealth = 5;
    public int currentHealth;

    [Header("Movement")]
    public float moveSpeed = 3f;
    public float stoppingDistance = 1.5f;

    [Header("Melee Attack")]
    public int damage = 1;
    public float attackRange = 1.5f;
    public float attackCooldown = 1.5f;

    private float attackTimer;
    private float throwTimer;

    void Start()
    {
        currentHealth = maxHealth;

        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");

            if (p != null)
                player = p.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(
            transform.position,
            player.position
        );

        attackTimer -= Time.deltaTime;
        throwTimer -= Time.deltaTime;

        // Movement
        if (distance > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                moveSpeed * Time.deltaTime
            );
        }

        // Melee attack
        if (distance <= attackRange && attackTimer <= 0f)
        {
            Attack();
            attackTimer = attackCooldown;
        }

        // Bomb throw attack
        if (distance <= 8f && throwTimer <= 0f)
        {
            ThrowBomb();
            throwTimer = throwCooldown;
        }

        FacePlayer();
    }

    void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(
            attackPoint.position,
            attackRange
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
    }

    void ThrowBomb()
    {
        if (bombPrefab == null || throwPoint == null)
            return;

        GameObject bomb = Instantiate(
            bombPrefab,
            throwPoint.position,
            Quaternion.identity
        );

        Vector2 direction =
            (player.position - throwPoint.position).normalized;

        BombProjectile bp = bomb.GetComponent<BombProjectile>();

        if (bp != null)
        {
            bp.SetDirection(direction);
        }
    }

    void FacePlayer()
    {
        if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        // Melee attack range
        if (attackPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(
                attackPoint.position,
                attackRange
            );
        }

        // Bomb range
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(
            transform.position,
            8f
        );
    }
}