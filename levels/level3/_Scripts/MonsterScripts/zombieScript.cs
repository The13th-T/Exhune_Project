using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lockOn = 10f;
    private float hit = 1f;
    private Transform target;
    private Transform door;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        door = GameObject.FindGameObjectWithTag("Door").GetComponent<Transform>();
    }
    void Update()
    {
    	if(target) {
    		if(checkLock() && !(checkHit()) && !(checkDoor()))
            	transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }                                
    
    bool checkHit() {
    	if(Vector2.Distance(transform.position, target.position) < hit) {
    		Debug.Log("Player hit!");
    		return true;
    	}
    	else
    		return false;
    }
    
    bool checkLock() {
    	if(Vector2.Distance(transform.position, target.position) < lockOn)
    		return true;
    	else
    		return false;
    }
    
    bool checkDoor() {
    	if(Vector2.Distance(transform.position, door.position) < hit)
    		return true;
    	else
    		return false;
    }
}