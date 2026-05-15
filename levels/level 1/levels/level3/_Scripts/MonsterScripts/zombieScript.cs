using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieScript : MonoBehaviour
{
	protected GameObject _player;
	[SerializeField] protected float _speed = 1.0f;
	
	public virtual void Init() {
		SetTarget();
	}
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    	Init();
    }
    
    // Update is called once per frame
    void Update()
    {
    	Chase();
    }
    
    protected virtual void SetTarget() {
    	if(GameObject.FindWithTag("Player") != null)
    		_player = GameObject.FindWithTag("Player");
    	else
    		Debug.LogError("Player not found!");
    }
    
    protected virtual void Chase() {
    	transform.right = _player.transform.position - transform.position;
    	transform.position += transform.right * _speed * Time.deltaTime;
    }
    
}
