using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMeleeEnemy : MonoBehaviour
{
    public static float correcter = -1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (this.transform.position.x != other.transform.position.x)
            {
                transform.Translate((other.transform.position.x * correcter)/2, 0, 0);
            }
        }
    }
}
