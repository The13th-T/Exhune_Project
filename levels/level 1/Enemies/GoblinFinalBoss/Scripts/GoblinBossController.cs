using UnityEngine;
using UnityEngine.AI;

public class GoblinBossController : MonoBehaviour
{
    public Transform player;
    public float health = 300f;

    public GoblinBossPhases phases;
    public GoblinBombAttack bombAttack;
    public GoblinSummonMinions summon;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!player) return;

        float dist = Vector3.Distance(transform.position, player.position);

        agent.SetDestination(player.position);

        phases.HandlePhase(health, this);

        if (dist < 2.5f)
        {
            MeleeAttack();
        }
    }

    void MeleeAttack()
    {
        Debug.Log("Goblin slashes!");
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;

        if (health <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log("Goblin King defeated!");
        Destroy(gameObject);
    }
}