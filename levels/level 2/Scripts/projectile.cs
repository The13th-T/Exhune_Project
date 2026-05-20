using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public static float shotSpeed = 10;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(shotSpeed * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyScript.hp -= 1;
            Destroy(gameObject);
        }
        else if (other.tag == "Enemy2")
        {
            enemyScript2.hp -= 1;
            Destroy(gameObject);
        }
        else if(other.tag == "wall")
        {
            Destroy(gameObject);
        }
    }
}
