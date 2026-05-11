using UnityEngine;

public class SpiderWebAttack : MonoBehaviour
{
    public GameObject webProjectile;
    public Transform shootPoint;

    public float cooldown = 3f;
    float timer;

    public void TryShootWeb()
    {
        timer += Time.deltaTime;

        if (timer >= cooldown)
        {
            Shoot();
            timer = 0;
        }
    }

    void Shoot()
    {
        Instantiate(webProjectile, shootPoint.position, shootPoint.rotation);
    }
}