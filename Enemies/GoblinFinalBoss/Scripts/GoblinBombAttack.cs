using UnityEngine;

public class GoblinBombAttack : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform throwPoint;

    public float cooldown = 2f;
    float timer;

    public void TryThrowBomb(float frequency)
    {
        timer += Time.deltaTime;

        if (timer >= cooldown)
        {
            if (Random.value < frequency)
            {
                ThrowBomb();
                timer = 0;
            }
        }
    }

    void ThrowBomb()
    {
        Instantiate(bombPrefab, throwPoint.position, throwPoint.rotation);
    }
}