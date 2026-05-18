using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    public float jumpForce = 5f;

    private float moveInput;

    private Rigidbody2D rb;

    [Header("Ground Check")]
    public Transform groundCheck;

    public float groundCheckRadius = 0.2f;

    public LayerMask groundLayer;

    private bool isGrounded;

    [Header("Shooting")]
    public GameObject fireballPrefab;

    public Transform firePoint;

    public float fireCooldown = 0.3f;

    private float nextFireTime;

    [Header("Slow Effect")]
    private float originalSpeed;

    private bool slowed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        originalSpeed = moveSpeed;
    }

    void Update()
    {
        HandleMovement();

        HandleJump();

        HandleShooting();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(
            moveInput * moveSpeed,
            rb.linearVelocity.y
        );
    }

    void HandleMovement()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
    }

    void HandleJump()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                jumpForce
            );
        }
    }

    void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.F) &&
            Time.time > nextFireTime)
        {
            Shoot();

            nextFireTime = Time.time + fireCooldown;
        }
    }

    void Shoot()
    {
        GameObject nearestEnemy = FindNearestEnemy();

        if (nearestEnemy == null)
        {
            return;
        }

        Vector2 direction =
            (nearestEnemy.transform.position -
            firePoint.position).normalized;

        GameObject fireball = Instantiate(
            fireballPrefab,
            firePoint.position,
            Quaternion.identity
        );

        fireball.GetComponent<Fireball>()
            .Launch(direction);
    }

    GameObject FindNearestEnemy()
    {
        GameObject[] enemies =
            GameObject.FindGameObjectsWithTag("Enemy");

        GameObject nearest = null;

        float shortestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(
                transform.position,
                enemy.transform.position
            );

            if (distance < shortestDistance)
            {
                shortestDistance = distance;

                nearest = enemy;
            }
        }

        return nearest;
    }

    public System.Collections.IEnumerator SlowEffect(
        float slowAmount,
        float duration
    )
    {
        if (slowed)
        {
            yield break;
        }

        slowed = true;

        moveSpeed = originalSpeed / slowAmount;

        yield return new WaitForSeconds(duration);

        moveSpeed = originalSpeed;

        slowed = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null)
        {
            return;
        }

        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(
            groundCheck.position,
            groundCheckRadius
        );
    }
}