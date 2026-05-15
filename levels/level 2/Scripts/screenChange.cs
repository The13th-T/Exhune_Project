using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class screenChange : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public string location;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

   
    void OnTriggerEnter(Collider other)
    {    
        SceneManager.LoadScene(location);
    }
}
