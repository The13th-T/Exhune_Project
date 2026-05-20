using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muzzleScript2 : MonoBehaviour
{
    public GameObject shot;
    public static bool isShooting = false;
    public float elapsedTime;
    private int seconds = 0;
    private int testCounter = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        seconds = Mathf.FloorToInt(elapsedTime % 120);

        if (isShooting == true)
        {
            if (seconds == 0)
            {
                Instantiate(shot, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                    Quaternion.identity);
                testCounter += 1;
            }
        }
        testCounter = 0;

        if (seconds == 2)
        {
            elapsedTime = 0;
        }
    }
}