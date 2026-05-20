using UnityEngine;

public class testShootEnemy : MonoBehaviour
{
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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.transform.position.x < 0)
            {
                muzzleScript.isShooting = true;
            }
            else
            {
                muzzleScript2.isShooting = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            muzzleScript.isShooting = false;
            muzzleScript2.isShooting = false;
        }
    }
}
