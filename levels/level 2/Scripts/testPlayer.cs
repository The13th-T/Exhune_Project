using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayer : MonoBehaviour
{
	public static string playerDirection = "right";
	public static float playerPositionX = 0;
	public static float playerPositionY = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		playerPositionX = transform.position.x;
		playerPositionY = transform.position.y;
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        
        Debug.DrawRay(transform.position, Vector3.down * 0.5f, Color.red);
        
        if (Input.GetKey("left"))
        {
            transform.Translate(-20 * Time.deltaTime, 0, 0);
			playerDirection = "left";
        }
        
        if (Input.GetKey("right"))
        {
            transform.Translate(20 * Time.deltaTime, 0, 0);
			playerDirection = "right";
        }
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.5f))
        {
            if (Input.GetKey("up"))
            {
                transform.Translate(0, 600 * Time.deltaTime, 0);
            }
        }
    }
}
