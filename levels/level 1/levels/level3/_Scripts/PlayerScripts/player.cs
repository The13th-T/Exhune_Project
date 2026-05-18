using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class player : MonoBehaviour
{
	public Vector3 jump = new Vector3(0.0f, 5.0f, 0.0f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    float factor = 5.0f;
    void Update()
    {
    	// Move right
        if(Keyboard.current != null && Keyboard.current.rightArrowKey.isPressed)
        	GetComponent<Rigidbody>().AddForce(Vector3.right * factor);
        // Move left
        if(Keyboard.current != null && Keyboard.current.leftArrowKey.isPressed)
        	GetComponent<Rigidbody>().AddForce(Vector3.left * factor);
        // Jump
        if(Input.GetKeyDown(KeyCode.UpArrow)) {
        	GetComponent<Rigidbody>().AddForce(Vector3.up * factor * 2, ForceMode.Impulse);
        }
    }
}