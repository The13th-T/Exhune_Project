using UnityEngine;

public class enemyScript2 : MonoBehaviour
{
    public static float hp = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            hp = 3;
            testShootEnemy.dead = true;
        }
    }
}
