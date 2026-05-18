using UnityEngine;
using UnityEngine.AI;

public class SpiderBossController : MonoBehaviour
{
    public Transform player;
    public float health = 200f;

    public SpiderBossPhases phases;
    public SpiderWebAttack webAttack;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!player) return;

        float distance = Vector3.Distance(transform.position, player.position);

        agent.SetDestination(player.position);

        phases.HandlePhase(health, this);

        if (distance < 3f)
        {
            Attack();
        }
    }

    void Attack()
    {
        Debug.Log("Spider melee attack!");
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;

        if (health <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log("Spider Boss Defeated!");
        Destroy(gameObject);
    }
}