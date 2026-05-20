using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMeleeEnemy : MonoBehaviour
{
    public static float correcter = -1;
    public static bool dead = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == true)
        {
            dead = false;
            Destroy(gameObject);
        }
    }
    
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.transform.position.x > 0)
            {
                correcter = -1;
            }
            else
            {
               correcter = 1;
            }
            if (this.transform.position.x != other.transform.position.x)
            {
                transform.Translate((1 * correcter), 0, 0);
            }
        }
    }
}
