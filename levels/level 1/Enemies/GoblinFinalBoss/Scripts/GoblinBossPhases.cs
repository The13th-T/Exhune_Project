using UnityEngine;

public class GoblinBossPhases : MonoBehaviour
{
    public void HandlePhase(float health, GoblinBossController boss)
    {
        if (health > 200)
            Phase1(boss);
        else if (health > 90)
            Phase2(boss);
        else
            Phase3(boss);
    }

    void Phase1(GoblinBossController boss)
    {
        boss.bombAttack.TryThrowBomb(0.01f);
    }

    void Phase2(GoblinBossController boss)
    {
        boss.bombAttack.TryThrowBomb(0.02f);
        boss.summon.TrySummon();
    }

    void Phase3(GoblinBossController boss)
    {
        var agent = boss.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = 7f;

        boss.bombAttack.TryThrowBomb(0.05f);
    }
}