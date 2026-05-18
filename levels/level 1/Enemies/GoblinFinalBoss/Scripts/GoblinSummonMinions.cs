using UnityEngine;

public class GoblinSummonMinions : MonoBehaviour
{
    public GameObject goblinPrefab;
    public Transform summonPoint;

    public float cooldown = 5f;
    float timer;

    public void TrySummon()
    {
        timer += Time.deltaTime;

        if (timer >= cooldown)
        {
            Instantiate(goblinPrefab, summonPoint.position, Quaternion.identity);
            timer = 0;
        }
    }
}