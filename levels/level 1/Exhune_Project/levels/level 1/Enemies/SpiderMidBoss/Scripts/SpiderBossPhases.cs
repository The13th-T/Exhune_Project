using UnityEngine;

public class SpiderBossPhases : MonoBehaviour
{
    public void HandlePhase(float health, SpiderBossController boss)
    {
        if (health > 120)
        {
            Phase1(boss);
        }
        else if (health > 60)
        {
            Phase2(boss);
        }
        else
        {
            Phase3(boss);
        }
    }

    void Phase1(SpiderBossController boss)
    {
        // Basic chase + melee
    }

    void Phase2(SpiderBossController boss)
    {
        // Spawn minions + web attacks
        boss.webAttack.TryShootWeb();
    }

    void Phase3(SpiderBossController boss)
    {
        // Faster + aggressive + AoE
        boss.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 6f;
    }
}